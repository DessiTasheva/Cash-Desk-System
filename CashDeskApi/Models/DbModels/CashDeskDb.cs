using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashDeskApi.Models.DbModels
{
    public class CashDeskDb
    {
        public int Id { get; set; }
        //The state of every cash desk depends on PeopleCount
        public CashDeskState State { get; set; }
        public int CameraId { get; set; }
        public bool IsOpen { get; set; }
        // Total number of people (PeopleIn - PeopleOut from Camera)
        public int PeopleCount { get; set; }
    }
}