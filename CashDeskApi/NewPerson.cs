using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashDeskApi.Models
{
    public class NewPerson
    {
        //This is a helper class for posting events
        //It help us indicate from which camera the event was triggered
        //And also wht kind of event it was - AddPeople ot RemovePeople

        public int cameraId { get; set; }
        public bool isAddPeople { get; set; }
    }
}