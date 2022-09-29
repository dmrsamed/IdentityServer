using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.MobilApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.MobilApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetPicture()
        {
            var pictureList = new List<Picture>

            {
                new Picture()
                {
                    Id = 1,
                    ResimAd = "Resim",
                    ResimUrl = "ResimUrl1"
                },
                new Picture()
                {
                    Id = 1,
                    ResimAd = "Resim2",
                    ResimUrl = "ResimUrl2"
                },
                new Picture()
                {
                    Id = 3,
                    ResimAd = "Resim3",
                    ResimUrl = "ResimUrl3"
                },
            };
            return Ok(pictureList);
        }
    }
}