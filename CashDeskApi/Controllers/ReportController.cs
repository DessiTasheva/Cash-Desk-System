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
    public class ReportController : ApiController
    {
        EventRepository eventRepository = new EventRepository();

        // GET api/<controller>
        public EventDto Get()
        {
            return eventRepository.GetAllEvents();
        }

       
        // POST api/<controller>
        [HttpPost]
        public void PostAdd([FromBody] NewPerson person)
        {
            int id = person.cameraId;
            bool isAdd = person.isAddPeople;

            if (isAdd)
            {
                eventRepository.AddPeopleEvent(id);
            }
            else
            {
                eventRepository.RemovePeopleEvent(id);
            }
        }

        
    }
}