using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashDeskApi.Models
{
    public class EventDto
    {
        public int PeopleIn { get; set; }
        public int PeopleOut { get; set; }
        //Key is cameraId and Value is Total of people on this camera for the day
        public Dictionary<int, int> cameraTotal { get; set; }
    }
}