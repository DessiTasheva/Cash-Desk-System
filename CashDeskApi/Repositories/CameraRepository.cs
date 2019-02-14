using CashDeskApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashDeskApi.Repositories
{
    public class CameraRepository
    {
        CashDesksContext _ctx = new CashDesksContext();

        public List<CameraDto> GetCameras()
        {
            // Get cameras from database
            var cameras = _ctx.Cameras.ToList();

            //New list to keep our CameraDto objects
            List<CameraDto> camerasDto = new List<CameraDto>();

            //Convert all cameras from CameraDb to CameraDto
            foreach (var camera in cameras)
            {
                CameraDto cameraDto = new CameraDto();

                cameraDto.Id = camera.Id;
                cameraDto.PeopleIn = camera.PeopleIn;
                cameraDto.PeopleOut = camera.PeopleOut;
                cameraDto.isCashDeskOpen = camera.IsCashDeskOpen;
                camerasDto.Add(cameraDto);
            }


            return camerasDto;
        }

        public CameraDto GetCameraById(int id)
        {
            //Find the camera in the database with the given id
            var camera = _ctx.Cameras.FirstOrDefault(c => c.Id == id);

            //Convert this object to CameraDto
            CameraDto cameraDto = new CameraDto();

            cameraDto.Id = camera.Id;
            cameraDto.PeopleIn = camera.PeopleIn;
            cameraDto.PeopleOut = camera.PeopleOut;
            cameraDto.isCashDeskOpen = camera.IsCashDeskOpen;

            return cameraDto;
        }

        public bool UpdateCamera(CameraDto camera)
        {
            //Find the given camera in the database
            var cameraDb = _ctx.Cameras.FirstOrDefault(c => c.Id == camera.Id);

            //Check if the object exists
            if (cameraDb != null)
            {
                //Convert the Dto object to Db object
                cameraDb.Id = camera.Id;
                cameraDb.PeopleIn = camera.PeopleIn;
                cameraDb.PeopleOut = camera.PeopleOut;
                cameraDb.IsCashDeskOpen = camera.isCashDeskOpen;
                
                //Save the updated Db object in the database
                _ctx.SaveChanges();
                //If the update is updated return true
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}