using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CashDeskApi.Controllers
{
    public class ImagesController : ApiController
    {
        [HttpGet]
        public string GetImageUrl()
        {
            return @"C:\Users\HP_\source\repos\CameraStatus\Picture\add-circle-green-512.png";
        }
    }
}
