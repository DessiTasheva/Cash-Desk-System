using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashDeskApi.Models
{
    public class CameraHistoricalEventsDto
    {
        public int EventId { get; set; }
        public int PeopleIn { get; set; }
        public int PeopleOut { get; set; }
        public DateTime UTCTimestamp { get; set; }
    }
}