﻿using System;
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
        public List<CashDeskDto> cashDesks = new List<CashDeskDto>
        {
            new CashDeskDto(){CameraId = 1, Id = 1, IsOpen = true, State = CashDeskState.Green},
            new CashDeskDto(){CameraId = 2, Id = 2, IsOpen = true, State = CashDeskState.Green},
            new CashDeskDto(){CameraId = 3, Id = 3, IsOpen = true, State = CashDeskState.Green},
            new CashDeskDto(){CameraId = 4, Id = 4, IsOpen = true, State = CashDeskState.Green},
        };

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<CashDeskDto> Get()
        {
            return cashDesks;
        }

        // GET api/<controller>/5
        [HttpGet]
        public CashDeskDto GetCashDesk(int id)
        {
            return cashDesks.FirstOrDefault(c => c.Id == id);
        }

        [HttpPut]
        public IHttpActionResult PutCamera(CashDeskDto cashDesk)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var existingCashDesk = cashDesks.FirstOrDefault(c => c.Id == cashDesk.Id);

            if (existingCashDesk != null)
            {
                existingCashDesk.State = cashDesk.State;
                existingCashDesk.IsOpen = cashDesk.IsOpen;
            }
            else
            {
                return NotFound();
            }


            return Ok();

        }


       
    }
}