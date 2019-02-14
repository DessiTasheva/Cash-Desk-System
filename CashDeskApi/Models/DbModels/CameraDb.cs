using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashDeskApi.Models.DbModels
{
    public class CameraDb
    {
        public int Id { get; set; }
        //Counts peopleIn and peopleOut for every camera
        public int PeopleIn { get; set; }
        public int PeopleOut { get; set; }
        public bool IsCashDeskOpen { get; set; }
    }
}