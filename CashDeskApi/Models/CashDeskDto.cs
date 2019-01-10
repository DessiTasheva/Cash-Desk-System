using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashDeskApi.Models
{
    public class CashDeskDto
    {
        private int id;
        private string name;
        private bool isOpened;

        

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOpened { get; set; } 
    }
}