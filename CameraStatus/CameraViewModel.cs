using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Input;
using System.Windows.Threading;
using CashDeskApi;
using CashDeskApi.Models;
using Newtonsoft.Json;

namespace CameraStatus
{
    public class CameraViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CameraDto> cameras = new ObservableCollection<CameraDto>();
        

        public ObservableCollection<CameraDto> Cameras
        {
            get { return cameras; }
            set
            {
                cameras = value;
                OnPropertyChanged("Cameras");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CameraViewModel()
        {
            Cameras = new ObservableCollection<CameraDto>();
            WebApiService.Initialize();

            InitaializeDataAsync();
            AddPeopleCommand = new DelegateCommand(AddPeople);
            RemovePeopleCommand = new DelegateCommand(RemovePeople);
        }



        /*private async Task InitaializeDataAsync()
        {
            
        }*/

        public async Task InitaializeDataAsync()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    Cameras = await WebApiService.GetCamerasAsync("http://localhost:56985/api/Cameras");
                    CheckIfCashDeskIsOpen();
                    await Task.Delay(1000);

                }
            });

        }


        public ICommand AddPeopleCommand { protected set; get; }
        public ICommand RemovePeopleCommand { protected set; get; }


        public async void AddPeople(object param)
        {
            var cameraId = (int)param;

            CameraDto camera = Cameras.FirstOrDefault(c => c.Id == cameraId);

            if (camera != null)
            {
                camera.PeopleIn++;
                await WebApiService.ChangeCamera("http://localhost:56985/api/Cameras", camera);
            }
            else
            {
                throw new Exception("Wrong camera id!");
            }

        }

        public async void RemovePeople(object param)
        {
            var cameraId = (int)param;

            CameraDto camera = Cameras.FirstOrDefault(c => c.Id == cameraId);
            if (camera != null)
            {
                camera.PeopleOut++;
                await WebApiService.ChangeCamera("http://localhost:56985/api/Cameras", camera);
            }
            else
            {
                throw new Exception("Wrong camera id!");
            }

        }

        public async Task CheckIfCashDeskIsOpen()
        {
            foreach (var camera in Cameras)
            {
                CashDeskDto cashDesk = await WebApiService
                    .GetCashDeskAsync($"http://localhost:56985/api/CashDesks/{camera.Id}");

                camera.isCashDeskOpen = cashDesk.IsOpen;

                await WebApiService.ChangeCamera("http://localhost:56985/api/Cameras", camera);
            }
        }
    }
}
