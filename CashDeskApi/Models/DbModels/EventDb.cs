using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashDeskApi.Models.DbModels
{
    public class EventDb
    {
        public int Id { get; set; }
        //If the event is AddPeopleEvent - PeopleIn is 1 and PeopleOut is 0
        //If the event is RemovePeopleEvent - PeopleOut is 1 and PeopleIn is 0
        public int PeopleIn { get; set; }
        public int PeopleOut { get; set; }
        public DateTime UTCTimestamp { get; set; }
        public int CameraId { get; set; }
    }
}