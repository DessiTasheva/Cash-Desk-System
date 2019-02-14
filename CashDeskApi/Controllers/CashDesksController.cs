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

            //Check if the change is done

            if (isFound)
            {
                return Ok();
            }


            return NotFound();

        }


       
    }
}