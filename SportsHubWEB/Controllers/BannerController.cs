using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsHubBL.Interfaces;
using SportsHubBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Extensions;

namespace SportsHubWEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BannerController : ControllerBase
    {
        private readonly IBannerService _bannerService;

        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }
        [HttpPost]
        public ActionResult AddBanner([FromBody] BannerModel model)
        {

            if (model == null)
            {
                return BadRequest("model was null");
            }
            try
            {
                _bannerService.AddBannerFromModel(model);
                _bannerService.AddNewBannerLocalizationFromModel(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return StatusCode(201);
        }


        [HttpPut("{id}")]

        public ActionResult UpdateBanner([FromRoute] int id, BannerModel model)
        {
            if (model == null)
            {
                return BadRequest("model was null");
            }
            try
            {
                _bannerService.UpdateBannerById(id, model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBanner([FromRoute] int id)
        {
            try
            {
                _bannerService.DeleteBannerById(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
        [HttpPost("localization")]
        public ActionResult AddNewBannerLocalizationFromModel([FromBody] BannerModel model)
        {
            if (model == null)
            {
                return BadRequest("model was null");
            }
            try
            {
                _bannerService.AddNewBannerLocalizationFromModel(model);
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return StatusCode(201);
        }
    

        [HttpGet]
        public ActionResult GetBanners
            (
            [FromQuery] int? categoryId,
            [FromQuery] int? bannerId,
            [FromQuery] bool? IsClosed
            )
        {
            int? languageId = 1;
            try
            {
                var result = _bannerService.GetBanners( categoryId, bannerId, IsClosed).Select(sa => _bannerService.GenerateBannerModel(sa, languageId ?? 1));
                if (result.IsNullOrEmpty())
                    return NotFound("Banners are not found");
                return Ok(result);
            }
            catch (ArgumentException)
            {
                return BadRequest("Banners are not found");
            }
        }
        [HttpPut("localization")]
        public ActionResult UpdateBannerLocalizationFromModel([FromBody] BannerModel model)
        {
            if (model == null)
            {
                return BadRequest("model was null");
            }
            try
            {
                _bannerService.UpdateBannerLocalizationFromModel(model);
               
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }
        [HttpDelete("localization")]
        public ActionResult DeleteBannerLocalizationById([FromQuery] int BannerId, int languageId)
        {
            try
            {
                _bannerService.DeleteBannerLocalizationById(BannerId, languageId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return NoContent();
        }

    }
}
