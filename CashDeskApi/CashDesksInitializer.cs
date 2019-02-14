using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CashDeskApi.Models;
using CashDeskApi.Models.DbModels;

namespace CashDeskApi
{
    public class CashDesksInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CashDesksContext>
    {
        protected override void Seed(CashDesksContext context)
        {

            List<CameraDb> cameras = new List<CameraDb>()
            {
            new CameraDb() {Id = 1, PeopleIn = 0, PeopleOut = 0, IsCashDeskOpen = true},
            new CameraDb() {Id = 2, PeopleIn = 0, PeopleOut = 0, IsCashDeskOpen = true},
            new CameraDb() {Id = 3, PeopleIn = 0, PeopleOut = 0, IsCashDeskOpen = true},
            new CameraDb() {Id = 4, PeopleIn = 0, PeopleOut = 0, IsCashDeskOpen = true}
            };

            cameras.ForEach(c => context.Cameras.Add(c));
            context.SaveChanges();

            List<CashDeskDb> cashDesks = new List<CashDeskDb>
            {
            new CashDeskDb(){CameraId = 1, Id = 1, IsOpen = true, State = CashDeskState.Green, PeopleCount = 0},
            new CashDeskDb(){CameraId = 2, Id = 2, IsOpen = true, State = CashDeskState.Green, PeopleCount = 0},
            new CashDeskDb(){CameraId = 3, Id = 3, IsOpen = true, State = CashDeskState.Green, PeopleCount = 0},
            new CashDeskDb(){CameraId = 4, Id = 4, IsOpen = true, State = CashDeskState.Green, PeopleCount = 0},
            };

            cashDesks.ForEach(c => context.CashDesks.Add(c));
            context.SaveChanges();
        }

    }

}
