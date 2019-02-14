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

    
}