using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashDeskApi.Models.DbModels
{
    public class EventDb
    {
        public int Id { get; set; }
        public int PeopleIn { get; set; }
        public int PeopleOut { get; set; }
        public DateTime UTCTimestamp { get; set; }
        public int CameraId { get; set; }
    }
}