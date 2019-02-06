using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CashDeskApi.Models;

namespace CashDeskApi.Controllers
{
    public class CamerasController : ApiController
    {
        public List<CameraDto> cameras = new List<CameraDto>()
        {
            new CameraDto() {Id = 1, PeopleIn = 0, PeopleOut = 0},
            new CameraDto() {Id = 2, PeopleIn = 0, PeopleOut = 0},
            new CameraDto() {Id = 3, PeopleIn = 0, PeopleOut = 0},
            new CameraDto() {Id = 4, PeopleIn = 0, PeopleOut = 0}
        };



        // GET api/<controller>
        [HttpGet]
        public IEnumerable<CameraDto> GetAllCameras()
        {
            return cameras;
        }

        // GET api/<controller>/5
        [HttpGet]
        public CameraDto GetCameraById(int id)
        {
            return cameras.FirstOrDefault(c => c.Id == id);
        }

        // PUT api/<controller>/5
        public IHttpActionResult PutCamera(int id,[FromBody] CameraDto camera)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var existingCamera = cameras.FirstOrDefault(c => c.Id == camera.Id);

            if (existingCamera != null)
            {
                existingCamera.PeopleIn = camera.PeopleIn;
                existingCamera.PeopleOut = camera.PeopleOut;
            }
            else
            {
                return NotFound();
            }


            return Ok();
        }
    }
}