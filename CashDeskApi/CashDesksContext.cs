using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CashDeskApi.Models.DbModels;

namespace CashDeskApi
{
    public class CashDesksContext:DbContext
    {
        public CashDesksContext() : base("CashDesksContext")
        {
        }

        public DbSet<CameraDb> Cameras { get; set; }
        public DbSet<CashDeskDb> CashDesks { get; set; }
        public DbSet<EventDb> Events { get; set; }
    }
}