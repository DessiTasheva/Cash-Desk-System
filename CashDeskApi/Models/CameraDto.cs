using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CashDeskApi.Models
{
    public class CameraDto
    {
        public int Id { get; set; }
        public int PeopleIn { get; set; }
        public int PeopleOut { get; set; }
        public bool isCashDeskOpen { get; set; }
        public bool IsPeopleCountZero { get; set; }
    }

    public class CameraViewModel:INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id;}
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private int peopleIn;
        public int PeopleIn
        {
            get { return peopleIn;}
            set
            {
                peopleIn = value;
                OnPropertyChanged(nameof(PeopleIn));
            }

        }

        private int peopleOut;
        public int PeopleOut
        {
            get { return peopleOut;}
            set
            {
                peopleOut = value;
                OnPropertyChanged(nameof(PeopleOut));
            }
        }

        private bool IsCashDeskOpen;

        public bool isCashDeskOpen
        {
            get { return IsCashDeskOpen; }
            set
            {
                IsCashDeskOpen = value;
                OnPropertyChanged(nameof(isCashDeskOpen));
            }
        }

        private bool isPeopleCountZero;

        public bool IsPeopleCountZero
        {
            get { return isPeopleCountZero; }
            set
            {
                isPeopleCountZero = value;
                OnPropertyChanged(nameof(IsPeopleCountZero));
            }
        }

        private bool isRemoveButtonDisabled;

        public bool IsRemoveButtonDisabled
        {
            get { return isRemoveButtonDisabled; }
            set
            {
                isRemoveButtonDisabled = value;
                OnPropertyChanged(nameof(IsRemoveButtonDisabled));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}