using System.Collections.ObjectModel;
using CashDeskApi.Models;


namespace CashDeskStatus.ViewModels
{
    public class CashDeskViewModel:BaseViewModel
    {
        public ObservableCollection<CashDeskDto> CashDesks { get; set; }

        public CashDeskViewModel()
        {
            CashDesks = new ObservableCollection<CashDeskDto>();

            CashDesks.Add(new CashDeskDto(){CameraId = 1, Id = 1, State = CashDeskState.Green, isOpen = true});
            CashDesks.Add(new CashDeskDto() { CameraId = 2, Id = 2, State = CashDeskState.Green, isOpen = true});
            CashDesks.Add(new CashDeskDto() { CameraId = 3, Id = 3, State = CashDeskState.Green, isOpen = false});
        }


    }
}
