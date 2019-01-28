using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CashDeskApi.Models;

namespace CashDeskApi.Controllers
{
    public class CashDesksController : ApiController
    {
        /*[HttpGet]
        public IList<CashDeskDto> GetAll()
        {
            var desks = GetCashDesks();
            return desks;
        }*/


       /* private List<CashDeskDto> GetCashDesks()
        {
            List<CashDeskDto> result = new List<CashDeskDto>();

            int number = new Random().Next(2, 5);
            for (int i = 0; i < number; i++)
            {
                result.Add(new CashDeskDto()
                {
                    Id = i,
                    Name = "CashDesk " + (i + 1),
                    IsOpened = i % 2 == 0
                });
            }

            return result;
        }*/


    }
}


