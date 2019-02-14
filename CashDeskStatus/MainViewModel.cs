using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CashDeskApi;
using CashDeskApi.Models;

namespace CashDeskStatus
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //Colection of CashDeskViewModels
        private ObservableCollection<CashDeskViewModel> cashDesks;
        public ObservableCollection<CashDeskViewModel> CashDesks
        {
            get { return cashDesks; }
            private set
            {
                cashDesks = value;
                OnPropertyChanged("CashDesks");
            }
        }

        public MainViewModel()
        {
            CashDesks = new ObservableCollection<CashDeskViewModel>();
            //Initialize web api service
            WebApiService.Initialize();

            InitaializeDataAsync();

            //Button commands
            OpenCashDeskCommand = new DelegateCommand(OpenCashDesk);
            CloseCashDeskCommand = new DelegateCommand(CloseCashDesk);
        }

        public async Task InitaializeDataAsync()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    //Get all cash desks
                    var cashDesksDtos = await WebApiService.GetCashDesksAsync();
                    //Helper colllection for keeping converted ViewModels
                    var convertedCashDesks = new ObservableCollection<CashDeskViewModel>();
                    //Convert from Dto to View model
                    foreach (var cashDeskDto in cashDesksDtos)
                    {
                        CashDeskViewModel cashdeskVm = new CashDeskViewModel();
                        cashdeskVm.Id = cashDeskDto.Id;
                        cashdeskVm.CameraId = cashDeskDto.CameraId;
                        cashdeskVm.IsPeopleCountZero = cashDeskDto.IsPeopleCountZero;
                        cashdeskVm.IsOpen = cashDeskDto.IsOpen;
                        cashdeskVm.PeopleCount = cashDeskDto.PeopleCount;
                        cashdeskVm.State = cashDeskDto.State;
                        convertedCashDesks.Add(cashdeskVm);
                    }
                    //Initialize the observable collection
                    CashDesks = convertedCashDesks;
                    //Check every second for people count
                    await CountPeople();
                    //Refresh every second
                    await Task.Delay(1000);
                    
                }
            });
            
        }

        public ICommand OpenCashDeskCommand { protected set; get; }
        public ICommand CloseCashDeskCommand { protected set; get; }

        // Change cash desk isOpen to true
        public async void OpenCashDesk(object param)
        {
            //Check which cash desk is opened
            var cashDeskId = (int)param;

            //Find cash desk in the collection
            var cashDeskVm = CashDesks.FirstOrDefault(c => c.Id == cashDeskId);

            //Check if she exists
            if (cashDeskVm != null)
            {
                // Change isOpen property to true
                cashDeskVm.IsOpen = true;

                //Convert to Dto object and change it with Web Api
                CashDeskDto cashdeskDto = new CashDeskDto();
                cashdeskDto.Id = cashDeskVm.Id;
                cashdeskDto.CameraId = cashDeskVm.CameraId;
                cashdeskDto.IsPeopleCountZero = cashDeskVm.IsPeopleCountZero;
                cashdeskDto.IsOpen = cashDeskVm.IsOpen;
                cashdeskDto.PeopleCount = cashDeskVm.PeopleCount;
                cashdeskDto.State = cashDeskVm.State;
                await WebApiService.ChangeCashDesk(cashdeskDto);
            }
            else
            {
                throw new Exception("Wrong cash desk id!");
            }

        }

        public async void CloseCashDesk(object param)
        {
            //Check which cash desk is closed
            var cashDeskId = (int)param;

            //Find cash desk in the collection
            var cashDeskVm = CashDesks.FirstOrDefault(c => c.Id == cashDeskId);

            //Check if she exists
            if (cashDeskVm != null)
            {
                // Change isOpen property to false
                cashDeskVm.IsOpen = false;

                //Convert to Dto object and change it with Web Api
                CashDeskDto cashdeskDto = new CashDeskDto();
                cashdeskDto.Id = cashDeskVm.Id;
                cashdeskDto.CameraId = cashDeskVm.CameraId;
                cashdeskDto.IsPeopleCountZero = cashDeskVm.IsPeopleCountZero;
                cashdeskDto.IsOpen = cashDeskVm.IsOpen;
                cashdeskDto.PeopleCount = cashDeskVm.PeopleCount;
                cashdeskDto.State = cashDeskVm.State;
                await WebApiService.ChangeCashDesk(cashdeskDto);
            }
            else
            {
                throw new Exception("Wrong cash desk id!");
            }

        }

       
        public async Task CountPeople()
        {
            foreach (var cashDeskVm in CashDesks)
            {
                int cameraId = cashDeskVm.CameraId;
                //Find the camera linked to the cash desk
                var camera = await WebApiService.GetCameraAsync($"http://localhost:56985/api/Cameras/{cameraId}");

                //Calculate people count
                cashDeskVm.PeopleCount = camera.PeopleIn - camera.PeopleOut;

                //Change cash desk state
                if (cashDeskVm.PeopleCount < 2)
                {
                    cashDeskVm.State = CashDeskState.Green;
                }
                else if(cashDeskVm.PeopleCount >= 2 && cashDeskVm.PeopleCount < 5)
                {
                    cashDeskVm.State = CashDeskState.Gray;
                }
                else
                {
                    cashDeskVm.State = CashDeskState.Red;
                }

                //Convert ViewModel to Dto and save changes
                CashDeskDto cashdeskDto = new CashDeskDto();
                cashdeskDto.Id = cashDeskVm.Id;
                cashdeskDto.CameraId = cashDeskVm.CameraId;
                cashdeskDto.IsPeopleCountZero = cashDeskVm.IsPeopleCountZero;
                cashdeskDto.IsOpen = cashDeskVm.IsOpen;
                cashdeskDto.PeopleCount = cashDeskVm.PeopleCount;
                cashdeskDto.State = cashDeskVm.State;
                await WebApiService.ChangeCashDesk(cashdeskDto);
            }
                
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
