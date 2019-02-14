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
            var cashDesks = _ctx.CashDesks.ToList();

            List<CashDeskDto> cashDesksDto = new List<CashDeskDto>();

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
            var cashDesk = _ctx.CashDesks.FirstOrDefault(c => c.CameraId == id);

            CashDeskDto cashDeskDto = new CashDeskDto();

            cashDeskDto.Id = cashDesk.Id;
            cashDeskDto.PeopleCount = cashDesk.PeopleCount;
            cashDeskDto.CameraId = cashDesk.CameraId;
            cashDeskDto.IsOpen = cashDesk.IsOpen;
            cashDeskDto.State = cashDesk.State;
            if (cashDesk.PeopleCount == 0)
            {
                cashDeskDto.IsPeopleCountZero = true;

            }

            else {cashDeskDto.IsPeopleCountZero = false;}

            return cashDeskDto;
        }

        public bool UpdateCashDesk(CashDeskDto cashDesk)
        {
            var cashDeskDb = _ctx.CashDesks.FirstOrDefault(c => c.Id == cashDesk.Id);

            if (cashDeskDb != null)
            {
                cashDeskDb.Id = cashDesk.Id;
                cashDeskDb.PeopleCount = cashDesk.PeopleCount;
                cashDeskDb.CameraId = cashDesk.CameraId;
                cashDeskDb.IsOpen = cashDesk.IsOpen;
                cashDeskDb.State = cashDesk.State;
                _ctx.SaveChanges();
                return true;
            }

            return false;
        }
    }
}