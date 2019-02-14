using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CameraStatus.ViewModels;
using CashDeskApi;
using CashDeskApi.Models;

namespace CameraStatus
{
    public class ReportPageViewModel:INotifyPropertyChanged
    {
        private ReportViewModel events = new ReportViewModel();

        public ReportViewModel Events
        {
            get { return events; }
            set
            {
                events = value;
                OnPropertyChanged("Events");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ReportPageViewModel()
        {
            Events = new ReportViewModel();
            WebApiService.Initialize();

            InitaializeDataAsync();
        }

        private async Task InitaializeDataAsync()
        {
            var eventsDto = await WebApiService.GetEventAsync("http://localhost:56985/api/Report");
            Events.PeopleIn = eventsDto.PeopleIn;
            Events.PeopleOut = eventsDto.PeopleOut;
            Events.cameraTotal = eventsDto.cameraTotal;
        }
    }
}
