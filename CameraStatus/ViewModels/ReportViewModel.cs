using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraStatus.ViewModels
{
    public class ReportViewModel:INotifyPropertyChanged
    {
        private int peopleIn;

        public int PeopleIn
        {
            get { return peopleIn; }
            set
            {
                peopleIn = value;
                OnPropertyChanged(nameof(PeopleIn));
            }
        }

        private int peopleOut;

        public int PeopleOut
        {
            get { return peopleOut; }
            set
            {
                peopleOut = value;
                OnPropertyChanged(nameof(PeopleOut));
            }
        }

        private Dictionary<int,int> CameraTotal;
        public Dictionary<int, int> cameraTotal {
            get { return CameraTotal; }
            set
            {
                CameraTotal = value;
                OnPropertyChanged(nameof(cameraTotal));
            } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
