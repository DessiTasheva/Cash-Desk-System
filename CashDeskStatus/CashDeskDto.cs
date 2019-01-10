using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CashDeskStatus.Annotations;

namespace CashDeskStatus
{
    public enum CashState
    {
        Green,
        Red,
        Yellow
    }
    public class CashDeskDto:INotifyPropertyChanged
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        private bool isOpened { get; set; }
        private int numberPeople { get; set; }
        private CashState state { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsOpened
        {
            get { return isOpened; }
            set
            {
                isOpened = value;
                // Call OnPropertyChanged whenever the property is updated
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsOpened"));
            }
        }

        public int NumberOfPeople
        {
            get { return numberPeople; }
            set
            {
                numberPeople = value;
                // Call OnPropertyChanged whenever the property is updated
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NumberOfPeople"));
            }
        }

        public CashState State
        {
            get { return state; }
            set
            {
                state = value;
                // Call OnPropertyChanged whenever the property is updated
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("State"));
            }
        }

    }
}
