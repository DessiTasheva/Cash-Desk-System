using System.Collections.ObjectModel;
using System.Windows.Input;
using CashDeskApi.Models;

namespace CameraStatus
{
    public class CameraViewModel:BaseViewModel
    {
        public ObservableCollection<CameraDto> Cameras { get; set; }
        
        public CameraViewModel()
        {
            Cameras = new ObservableCollection<CameraDto>();

            Cameras.Add(new CameraDto(){Id=1, PeopleIn = 0, PeopleOut = 0});
            Cameras.Add(new CameraDto() { Id = 2, PeopleIn = 0, PeopleOut = 0 });
            Cameras.Add(new CameraDto() { Id = 3, PeopleIn = 0, PeopleOut = 0 });

            AddPeopleCommand = new DelegateCommand(AddPeople);
            RemovePeopleCommand = new DelegateCommand(RemovePeople);
        }

        // Commands

        public ICommand AddPeopleCommand { protected set; get; }
        public ICommand RemovePeopleCommand { protected set; get; }


        public void AddPeople(object param)
        {
            
        }

       
        public void RemovePeople(object param)
        {

        }

    }
}
