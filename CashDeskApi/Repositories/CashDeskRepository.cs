using CashDeskApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashDeskApi.Repositories
{
    public class CashDeskRepository
    {
        CashDesksContext _ctx = new CashDesksContext();

        public List<CashDeskDto> GetCashDesks()
        {
            //Get all cash desks from the database
            var cashDesks = _ctx.CashDesks.ToList();

            //New list to keep our CashDeskDto objects
            List<CashDeskDto> cashDesksDto = new List<CashDeskDto>();

            //Convert all cash desks from Db to Dto
            foreach (var cashDesk in cashDesks)
            {
                CashDeskDto cashDeskDto = new CashDeskDto();

                cashDeskDto.Id = cashDesk.Id;
                cashDeskDto.PeopleCount = cashDesk.PeopleCount;
                cashDeskDto.CameraId = cashDesk.CameraId;
                cashDeskDto.IsOpen = cashDesk.IsOpen;
                cashDeskDto.State = cashDesk.State;
                cashDesksDto.Add(cashDeskDto);
            }

            return cashDesksDto;
        }

        public CashDeskDto GetCashDeskByCameraId(int id)
        {
            //Find the cash desk by the given cameraId
            var cashDesk = _ctx.CashDesks.FirstOrDefault(c => c.CameraId == id);

            //Convert this object to CashDeskDto
            CashDeskDto cashDeskDto = new CashDeskDto();

            cashDeskDto.Id = cashDesk.Id;
            cashDeskDto.PeopleCount = cashDesk.PeopleCount;
            cashDeskDto.CameraId = cashDesk.CameraId;
            cashDeskDto.IsOpen = cashDesk.IsOpen;
            cashDeskDto.State = cashDesk.State;
            //Check the current people count and initialize IsPeopleCountZero
            if (cashDesk.PeopleCount == 0)
            {
                cashDeskDto.IsPeopleCountZero = true;

            }

            else
            {
                cashDeskDto.IsPeopleCountZero = false;
            }

            return cashDeskDto;
        }

        public bool UpdateCashDesk(CashDeskDto cashDesk)
        {
            //Find the given cash desk in the database
            var cashDeskDb = _ctx.CashDesks.FirstOrDefault(c => c.Id == cashDesk.Id);

            //Check if the object exists
            if (cashDeskDb != null)
            {
                //Convert the Dto object to Db object
                cashDeskDb.Id = cashDesk.Id;
                cashDeskDb.PeopleCount = cashDesk.PeopleCount;
                cashDeskDb.CameraId = cashDesk.CameraId;
                cashDeskDb.IsOpen = cashDesk.IsOpen;
                cashDeskDb.State = cashDesk.State;
                //Save the updated Db object in the database
                _ctx.SaveChanges();
                //If the update is updated return true
                return true;
            }

            return false;
        }
    }
}