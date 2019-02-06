using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Input;
using CashDeskApi.Models;
using Newtonsoft.Json;

namespace CameraStatus
{
    public class CameraViewModel: INotifyPropertyChanged
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
            ClientHelper.Initialize();
            
            InitaializeDataAsync();
            AddPeopleCommand = new DelegateCommand(AddPeople);
            RemovePeopleCommand = new DelegateCommand(RemovePeople);
        }

        private async Task InitaializeDataAsync()
        {
            Cameras = await ClientHelper.GetCamerasAsync("http://localhost:56985/api/Cameras");
        }

        public ICommand AddPeopleCommand { protected set; get; }
        public ICommand RemovePeopleCommand { protected set; get; }


        public async void AddPeople(object param)
        {
            var cameraId = (int) param;

            CameraDto camera = Cameras.FirstOrDefault(c => c.Id == cameraId);

            if (camera != null)
            {
                camera.PeopleIn++;
                await ClientHelper.ChangeCamera("http://localhost:56985/api/Cameras", camera);
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
                await ClientHelper.ChangeCamera("http://localhost:56985/api/Cameras", camera);
            }
            else
            {
                throw new Exception("Wrong camera id!");
            }
            
        }


    }
}
