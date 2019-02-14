using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CashDeskApi.Models;
using CashDeskApi.Repositories;

namespace CashDeskApi.Controllers
{
    public class CashDesksController : ApiController
    {
        /*public static List<CashDeskDto> cashDesks = new List<CashDeskDto>
        {
            new CashDeskDto(){CameraId = 1, Id = 1, IsOpen = true, State = CashDeskState.Green, PeopleCount = 10},
            new CashDeskDto(){CameraId = 2, Id = 2, IsOpen = true, State = CashDeskState.Green, PeopleCount = 0},
            new CashDeskDto(){CameraId = 3, Id = 3, IsOpen = true, State = CashDeskState.Green, PeopleCount = 8},
            new CashDeskDto(){CameraId = 4, Id = 4, IsOpen = true, State = CashDeskState.Green, PeopleCount = 0},
        };*/

        CashDeskRepository cashDeskRepository = new CashDeskRepository();

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<CashDeskDto> Get()
        {
            return cashDeskRepository.GetCashDesks();
        }

        // GET api/<controller>/5
        [HttpGet]
        public CashDeskDto GetCashDeskByCameraId(int id)
        {
            return cashDeskRepository.GetCashDeskByCameraId(id);
        }

       
        [HttpPut]
        public IHttpActionResult PutCamera(CashDeskDto cashDesk)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            bool isFound = cashDeskRepository.UpdateCashDesk(cashDesk);

            if(isFound)
            {
                return Ok();
            }


            return NotFound();

        }


       
    }
}