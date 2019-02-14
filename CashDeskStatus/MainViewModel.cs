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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainViewModel()
        {
            CashDesks = new ObservableCollection<CashDeskViewModel>();
            WebApiService.Initialize();

            InitaializeDataAsync();

            OpenCashDeskCommand = new DelegateCommand(OpenCashDesk);
            CloseCashDeskCommand = new DelegateCommand(CloseCashDesk);
        }

        public async Task InitaializeDataAsync()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    var cashDesksDtos = await WebApiService.GetCashDesksAsync("http://localhost:56985/api/CashDesks");
                    var convertedCashDesks = new ObservableCollection<CashDeskViewModel>();
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

                    CashDesks = convertedCashDesks;
                    await CountPeople();
                    await Task.Delay(1000);
                    
                }
            });
            
        }

        public ICommand OpenCashDeskCommand { protected set; get; }
        public ICommand CloseCashDeskCommand { protected set; get; }

        public async void OpenCashDesk(object param)
        {
            var cashDeskId = (int)param;

            var cashDeskVm = CashDesks.FirstOrDefault(c => c.Id == cashDeskId);

            if (cashDeskVm != null)
            {
                cashDeskVm.IsOpen = true;

                CashDeskDto cashdeskDto = new CashDeskDto();
                cashdeskDto.Id = cashDeskVm.Id;
                cashdeskDto.CameraId = cashDeskVm.CameraId;
                cashdeskDto.IsPeopleCountZero = cashDeskVm.IsPeopleCountZero;
                cashdeskDto.IsOpen = cashDeskVm.IsOpen;
                cashdeskDto.PeopleCount = cashDeskVm.PeopleCount;
                cashdeskDto.State = cashDeskVm.State;
                await WebApiService.ChangeCashDesk("http://localhost:56985/api/CashDesks", cashdeskDto);
            }
            else
            {
                throw new Exception("Wrong cash desk id!");
            }

        }

        public async void CloseCashDesk(object param)
        {
            var cashDeskId = (int)param;

            var cashDeskVm = CashDesks.FirstOrDefault(c => c.Id == cashDeskId);

            if (cashDeskVm != null)
            {
                cashDeskVm.IsOpen = false;
                CashDeskDto cashdeskDto = new CashDeskDto();
                cashdeskDto.Id = cashDeskVm.Id;
                cashdeskDto.CameraId = cashDeskVm.CameraId;
                cashdeskDto.IsPeopleCountZero = cashDeskVm.IsPeopleCountZero;
                cashdeskDto.IsOpen = cashDeskVm.IsOpen;
                cashdeskDto.PeopleCount = cashDeskVm.PeopleCount;
                cashdeskDto.State = cashDeskVm.State;
                await WebApiService.ChangeCashDesk("http://localhost:56985/api/CashDesks", cashdeskDto);
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
                var camera = await WebApiService.GetCameraAsync($"http://localhost:56985/api/Cameras/{cameraId}");

                cashDeskVm.PeopleCount = camera.PeopleIn - camera.PeopleOut;

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

                CashDeskDto cashdeskDto = new CashDeskDto();
                cashdeskDto.Id = cashDeskVm.Id;
                cashdeskDto.CameraId = cashDeskVm.CameraId;
                cashdeskDto.IsPeopleCountZero = cashDeskVm.IsPeopleCountZero;
                cashdeskDto.IsOpen = cashDeskVm.IsOpen;
                cashdeskDto.PeopleCount = cashDeskVm.PeopleCount;
                cashdeskDto.State = cashDeskVm.State;
                await WebApiService.ChangeCashDesk("http://localhost:56985/api/CashDesks", cashdeskDto);
            }
                
            
        }

    }
}
