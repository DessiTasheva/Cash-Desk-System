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
        public IHttpActionResult PutCamera(CameraDto camera)
        {
            if (!ModelState.IsValid)
                throw new Exception("Camera model is not valid");

            bool isFound = cameraRepository.UpdateCamera(camera);

            //Check if the change is done
            if (isFound)
            {
                return Ok();
            }


            return NotFound();
        }
    }
}