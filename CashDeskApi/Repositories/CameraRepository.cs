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
            var cameras = _ctx.Cameras.ToList();

            List<CameraDto> camerasDto = new List<CameraDto>();

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
            var camera = _ctx.Cameras.FirstOrDefault(c => c.Id == id);

            CameraDto cameraDto = new CameraDto();

            cameraDto.Id = camera.Id;
            cameraDto.PeopleIn = camera.PeopleIn;
            cameraDto.PeopleOut = camera.PeopleOut;
            cameraDto.isCashDeskOpen = camera.IsCashDeskOpen;

            return cameraDto;
        }

        public int UpdateCamera(CameraDto camera)
        {
            var cameraDb = _ctx.Cameras.FirstOrDefault(c => c.Id == camera.Id);

            if (cameraDb != null)
            {
                cameraDb.Id = camera.Id;
                cameraDb.PeopleIn = camera.PeopleIn;
                cameraDb.PeopleOut = camera.PeopleOut;
                cameraDb.IsCashDeskOpen = camera.isCashDeskOpen;
                
                _ctx.SaveChanges();
                return cameraDb.PeopleIn - cameraDb.PeopleOut;
            }
            else
            {
                throw new Exception("Camera does not exist");
            }
            
        }
    }
}