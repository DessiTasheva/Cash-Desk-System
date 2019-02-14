using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CameraStatus.ViewModels;
using CashDeskApi;
using CashDeskApi.Models;

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

        public MainViewModel()
        {
            Cameras = new ObservableCollection<CameraViewModel>();
            WebApiService.Initialize();

            InitaializeDataAsync();

            //Button commands
            AddPeopleCommand = new DelegateCommand(AddPeople);
            RemovePeopleCommand = new DelegateCommand(RemovePeople);
        }
        

        public async Task InitaializeDataAsync()
        {
            await Task.Run(async () =>
            {
                //Get all cameras
                var camerasDtos = await WebApiService.GetCamerasAsync();
                //Helper collection which keeps all converted cameras
                var convertedCameras = new ObservableCollection<CameraViewModel>();
                //Convert every camera from Dto to ViewModel
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
            }).ContinueWith(async t => { await UpdateDataAsync();});
            // After finishing with Initializing, the program continues with UpdateDataAsync

        }

        public async Task UpdateDataAsync()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    var camerasDtos = await WebApiService.GetCamerasAsync();
                    //Update only the properties that are changing
                    foreach (var camera in camerasDtos)
                    {
                        //Find the camera that we are updating from the ObservableCollection
                        var cameraVm = Cameras.FirstOrDefault(c => c.Id == camera.Id);
                        if (cameraVm != null)
                        {
                            cameraVm.PeopleIn = camera.PeopleIn;
                            cameraVm.PeopleOut = camera.PeopleOut;
                            cameraVm.isCashDeskOpen = camera.isCashDeskOpen;
                            cameraVm.IsPeopleCountZero = camera.IsPeopleCountZero;
                        }

                    }

                    await CheckIfCashDeskIsOpen();
                    await Task.Delay(1000);

                }
            });

        }


        public ICommand AddPeopleCommand { protected set; get; }
        public ICommand RemovePeopleCommand { protected set; get; }


        public async void AddPeople(object param)
        {
            //Find from which camera the event was triggered
            var cameraId = (int)param;

            //Find the camera
            CameraViewModel cameraVM = Cameras.FirstOrDefault(c => c.Id == cameraId);
            
            //Check if the camera exists
            if (cameraVM != null)
            {
                //Convert ViewModel to Dto
                CameraDto cameraDto = new CameraDto();
                cameraDto.Id = cameraVM.Id;
                cameraDto.PeopleIn = cameraVM.PeopleIn;
                cameraDto.PeopleOut = cameraVM.PeopleOut;
                cameraDto.isCashDeskOpen = cameraVM.isCashDeskOpen;
                cameraDto.IsPeopleCountZero = cameraVM.IsPeopleCountZero;
                //Increase the number of people
                cameraDto.PeopleIn++;
                //Create helper object for our event to determine from which camera the event was trigger
                //And if the event was AddPeople
                NewPerson person = new NewPerson { cameraId = cameraId, isAddPeople = true };
                //Post event
                await WebApiService.PostEvent(person);
                //Change camera
                await WebApiService.ChangeCamera(cameraDto);
                
            }
            else
            {
                throw new Exception("Wrong camera id!");
            }

        }

        public async void RemovePeople(object param)
        {
            //Find from which camera the event was triggered
            var cameraId = (int)param;

            //Find the camera
            CameraViewModel cameraVM = Cameras.FirstOrDefault(c => c.Id == cameraId);

            if (cameraVM != null)
            {
                //Convert ViewModel to Dto
                CameraDto cameraDto = new CameraDto();
                cameraDto.Id = cameraVM.Id;
                cameraDto.PeopleIn = cameraVM.PeopleIn;
                cameraDto.PeopleOut = cameraVM.PeopleOut;
                cameraDto.isCashDeskOpen = cameraVM.isCashDeskOpen;
                cameraDto.IsPeopleCountZero = cameraVM.IsPeopleCountZero;
                //Decrease the number of people
                cameraDto.PeopleIn--;
                //Create helper object for our event to determine from which camera the event was trigger
                //And if the event was AddPeople
                NewPerson person = new NewPerson { cameraId = cameraId, isAddPeople = false };
                //Post event
                await WebApiService.PostEvent(person);
                //Change camera
                await WebApiService.ChangeCamera(cameraDto);

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
                //Get cashDesk with cameraId
                CashDeskDto cashDesk = await WebApiService
                    .GetCashDeskAsync($"http://localhost:56985/api/CashDesks/{cameraVM.Id}");

                //Checks if cashDesk is open and if there are 0 people
                cameraVM.isCashDeskOpen = cashDesk.IsOpen;
                cameraVM.IsPeopleCountZero = cashDesk.IsPeopleCountZero;
                //Changes the IsRemoveButtonDisabled property if the cash desk isClosed
                //or if there are 0 people
                if (cameraVM.isCashDeskOpen == false || cameraVM.IsPeopleCountZero)
                {
                    cameraVM.IsRemoveButtonDisabled = false;
                }
                else
                {
                    cameraVM.IsRemoveButtonDisabled = true;
                }

                //Converts the updated ViewModel to Dto
                CameraDto cameraDto = new CameraDto();
                cameraDto.Id = cameraVM.Id;
                cameraDto.PeopleIn = cameraVM.PeopleIn;
                cameraDto.PeopleOut = cameraVM.PeopleOut;
                cameraDto.isCashDeskOpen = cameraVM.isCashDeskOpen;
                cameraDto.IsPeopleCountZero = cameraVM.IsPeopleCountZero;

                //Changes camera
                await WebApiService.ChangeCamera(cameraDto);

            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
