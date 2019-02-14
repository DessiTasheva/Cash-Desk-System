using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CashDeskApi.Models;
using CashDeskApi.Repositories;

namespace CashDeskApi.Controllers
{
    public class CamerasController : ApiController
    {
        /*public static List<CameraDto> cameras = new List<CameraDto>()
        {
            new CameraDto() {Id = 1, PeopleIn = 0, PeopleOut = 0},
            new CameraDto() {Id = 2, PeopleIn = 0, PeopleOut = 0},
            new CameraDto() {Id = 3, PeopleIn = 0, PeopleOut = 0},
            new CameraDto() {Id = 4, PeopleIn = 0, PeopleOut = 0}
        };*/

        private CameraRepository cameraRepository = new CameraRepository();

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<CameraDto> GetAllCameras()
        {
            return cameraRepository.GetCameras();
        }

        // GET api/<controller>/5
        [HttpGet]
        public CameraDto GetCameraById(int id)
        {
            return cameraRepository.GetCameraById(id);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public int PutCamera(CameraDto camera)
        {
            if (!ModelState.IsValid)
                throw new Exception("Camera model is not valid");

            int numberOfPeople = cameraRepository.UpdateCamera(camera);
           

            return numberOfPeople;
        }
    }
}