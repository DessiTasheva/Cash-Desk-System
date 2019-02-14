using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashDeskApi;
using CashDeskApi.Models;

namespace CameraStatus
{
    public class ReportViewModel:INotifyPropertyChanged
    {
        private EventDto events = new EventDto();

        public EventDto Events
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

        public ReportViewModel()
        {
            Events = new EventDto();
            WebApiService.Initialize();

            InitaializeDataAsync();
        }

        private async Task InitaializeDataAsync()
        {
            Events = await WebApiService.GetEventAsync("http://localhost:56985/api/Report");
        }
    }
}
