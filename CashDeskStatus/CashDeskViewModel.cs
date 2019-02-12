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
    public class CashDeskViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CashDeskDto> cashDesks;
        public ObservableCollection<CashDeskDto> CashDesks
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

        public CashDeskViewModel()
        {
            CashDesks = new ObservableCollection<CashDeskDto>();
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
                    CashDesks = await WebApiService.GetCashDesksAsync("http://localhost:56985/api/CashDesks");
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

            CashDeskDto cashDesk = CashDesks.FirstOrDefault(c => c.Id == cashDeskId);

            if (cashDesk != null)
            {
                cashDesk.IsOpen = true;
                await WebApiService.ChangeCashDesk("http://localhost:56985/api/CashDesks", cashDesk);
            }
            else
            {
                throw new Exception("Wrong cash desk id!");
            }

        }

        public async void CloseCashDesk(object param)
        {
            var cashDeskId = (int)param;

            CashDeskDto cashDesk = CashDesks.FirstOrDefault(c => c.Id == cashDeskId);

            if (cashDesk != null)
            {
                cashDesk.IsOpen = false;
                await WebApiService.ChangeCashDesk("http://localhost:56985/api/CashDesks", cashDesk);
            }
            else
            {
                throw new Exception("Wrong cash desk id!");
            }

        }

       
        public async Task CountPeople()
        {
            foreach (var cashDesk in CashDesks)
            {
                int cameraId = cashDesk.CameraId;
                var camera = await WebApiService.GetCameraAsync($"http://localhost:56985/api/Cameras/{cameraId}");
                cashDesk.PeopleCount = camera.PeopleIn - camera.PeopleOut;
                if (cashDesk.PeopleCount < 2)
                {
                    cashDesk.State = CashDeskState.Green;
                }
                else if(cashDesk.PeopleCount >= 2 && cashDesk.PeopleCount < 5)
                {
                    cashDesk.State = CashDeskState.Gray;
                }
                else
                {
                    cashDesk.State = CashDeskState.Red;
                }
                await WebApiService.ChangeCashDesk("http://localhost:56985/api/CashDesks", cashDesk);
            }
                
            
        }

    }
}
