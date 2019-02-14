using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashDeskApi.Models;

namespace CashDeskStatus
{
    public class CashDeskViewModel : INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private CashDeskState state;
        public CashDeskState State
        {
            get { return state; }
            set
            {
                state = value;
                OnPropertyChanged(nameof(State));
            }
        }

        private int cameraId;
        public int CameraId
        {
            get { return cameraId; }
            set
            {
                cameraId = value;
                OnPropertyChanged(nameof(CameraId));
            }
        }

        private bool isOpen;
        public bool IsOpen
        {
            get { return isOpen; }
            set
            {
                isOpen = value;
                OnPropertyChanged(nameof(IsOpen));
            }
        }

        private int peopleCount;

        public int PeopleCount
        {
            get { return peopleCount; }
            set
            {
                peopleCount = value;
                OnPropertyChanged(nameof(PeopleCount));
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
