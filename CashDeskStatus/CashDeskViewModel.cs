using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CashDeskApi.Models;

namespace CashDeskStatus
{
    public class CashDeskViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CashDeskDto> cashDesks;
        public ObservableCollection<CashDeskDto> CashDesks
        {
            get { return cashDesks;}
            private set { cashDesks = value;
                OnPropertyChanged("CashDesks");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public CashDeskViewModel()
        {
            CashDesks = new ObservableCollection<CashDeskDto>();
            ClientHelper.Initialize();
            
            InitaializeDataAsync();

            OpenCashDeskCommand = new DelegateCommand(OpenCashDesk);
            CloseCashDeskCommand = new DelegateCommand(CloseCashDesk);
        }

        private async Task InitaializeDataAsync()
        {
            CashDesks = await ClientHelper.GetCashDesksAsync("http://localhost:56985/api/CashDesks");
        }

        public ICommand OpenCashDeskCommand { protected set; get; }
        public ICommand CloseCashDeskCommand { protected set; get; }

        public async void OpenCashDesk(object param)
        {
            var cashDeskId = (int)param;

            CashDeskDto cashDesk = CashDesks.FirstOrDefault(c => c.Id == cashDeskId);

            if (cashDesk != null)
            {
                cashDesk.IsOpen = true;
                await ClientHelper.ChangeCashDesk("http://localhost:56985/api/CashDesks", cashDesk);
            }
            else
            {
                throw new Exception("Wrong cash desk id!");
            }

        }

        public async void CloseCashDesk(object param)
        {
            var cashDeskId = (int)param;

            CashDeskDto cashDesk = CashDesks.FirstOrDefault(c => c.Id == cashDeskId);

            if (cashDesk != null)
            {
                cashDesk.IsOpen = false;
                await ClientHelper.ChangeCashDesk("http://localhost:56985/api/CashDesks", cashDesk);
            }
            else
            {
                throw new Exception("Wrong cash desk id!");
            }

        }

    }
}
