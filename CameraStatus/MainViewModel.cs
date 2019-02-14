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
using CashDeskApi.Repositories;
using Newtonsoft.Json;

namespace CameraStatus
{
    public class MainViewModel : INotifyPropertyChanged
    {
        
        private ObservableCollection<CameraViewModel> cameras = new ObservableCollection<CameraViewModel>();
        

        public ObservableCollection<CameraViewModel> Cameras
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

        public MainViewModel()
        {
            Cameras = new ObservableCollection<CameraViewModel>();
            WebApiService.Initialize();

            InitaializeDataAsync();
            AddPeopleCommand = new DelegateCommand(AddPeople);
            RemovePeopleCommand = new DelegateCommand(RemovePeople);
        }
        

        public async Task InitaializeDataAsync()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    
                    var camerasDtos = await WebApiService.GetCamerasAsync("http://localhost:56985/api/Cameras");
                    var convertedCameras = new ObservableCollection<CameraViewModel>();
                    foreach (var camera in camerasDtos)
                    {
                        CameraViewModel cameraVm = new CameraViewModel();
                        cameraVm.Id = camera.Id;
                        cameraVm.PeopleIn = camera.PeopleIn;
                        cameraVm.PeopleOut = camera.PeopleOut;
                        cameraVm.isCashDeskOpen = camera.isCashDeskOpen;
                        cameraVm.IsPeopleCountZero = camera.IsPeopleCountZero;
                        
                        convertedCameras.Add(cameraVm);
                    }

                    Cameras = convertedCameras;
                    await CheckIfCashDeskIsOpen();
                    await Task.Delay(5000);

                }
            });

        }


        public ICommand AddPeopleCommand { protected set; get; }
        public ICommand RemovePeopleCommand { protected set; get; }


        public async void AddPeople(object param)
        {
            var cameraId = (int)param;

            CameraViewModel cameraVM = Cameras.FirstOrDefault(c => c.Id == cameraId);

            

            if (cameraVM != null)
            {
                CameraDto cameraDto = new CameraDto();
                cameraDto.Id = cameraVM.Id;
                cameraDto.PeopleIn = cameraVM.PeopleIn;
                cameraDto.PeopleOut = cameraVM.PeopleOut;
                cameraDto.isCashDeskOpen = cameraVM.isCashDeskOpen;
                cameraDto.IsPeopleCountZero = cameraVM.IsPeopleCountZero;
                cameraDto.PeopleIn++;
                NewPerson person = new NewPerson { cameraId = cameraId, isAddPeople = true };
                await WebApiService.PostEvent("http://localhost:56985/api/Report", person);
                await WebApiService.ChangeCamera("http://localhost:56985/api/Cameras", cameraDto);
                
            }
            else
            {
                throw new Exception("Wrong camera id!");
            }

        }

        public async void RemovePeople(object param)
        {
            var cameraId = (int)param;

            CameraViewModel cameraVM = Cameras.FirstOrDefault(c => c.Id == cameraId);



            if (cameraVM != null)
            {
                CameraDto cameraDto = new CameraDto();
                cameraDto.Id = cameraVM.Id;
                cameraDto.PeopleIn = cameraVM.PeopleIn;
                cameraDto.PeopleOut = cameraVM.PeopleOut;
                cameraDto.isCashDeskOpen = cameraVM.isCashDeskOpen;
                cameraDto.IsPeopleCountZero = cameraVM.IsPeopleCountZero;
                cameraDto.PeopleIn--;
                NewPerson person = new NewPerson { cameraId = cameraId, isAddPeople = true };
                await WebApiService.PostEvent("http://localhost:56985/api/Report", person);
                await WebApiService.ChangeCamera("http://localhost:56985/api/Cameras", cameraDto);

            }
            else
            {
                throw new Exception("Wrong camera id!");
            }

        }

        public async Task CheckIfCashDeskIsOpen()
        {
            foreach (var cameraVM in Cameras)
            {
                CashDeskDto cashDesk = await WebApiService
                    .GetCashDeskAsync($"http://localhost:56985/api/CashDesks/{cameraVM.Id}");

                cameraVM.isCashDeskOpen = cashDesk.IsOpen;
                cameraVM.IsPeopleCountZero = cashDesk.IsPeopleCountZero;
                if (cameraVM.isCashDeskOpen == false || cameraVM.IsPeopleCountZero)
                {
                    cameraVM.IsRemoveButtonDisabled = false;
                }
                else
                {
                    cameraVM.IsRemoveButtonDisabled = true;
                }

                CameraDto cameraDto = new CameraDto();
                cameraDto.Id = cameraVM.Id;
                cameraDto.PeopleIn = cameraVM.PeopleIn;
                cameraDto.PeopleOut = cameraVM.PeopleOut;
                cameraDto.isCashDeskOpen = cameraVM.isCashDeskOpen;
                cameraDto.IsPeopleCountZero = cameraVM.IsPeopleCountZero;


                await WebApiService.ChangeCamera("http://localhost:56985/api/Cameras", cameraDto);

            }
        }
    }
}
