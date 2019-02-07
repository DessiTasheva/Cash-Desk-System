using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashDeskApi.Models
{
    public class CashDeskDto
    {
        public int Id { get; set; }
        public CashDeskState State { get; set; }
        public int CameraId { get; set; }
        public bool IsOpen { get; set; }
        public int PeopleCount { get; set; }
    }
}