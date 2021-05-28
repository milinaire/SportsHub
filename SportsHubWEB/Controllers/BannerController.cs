using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsHubBL.Interfaces;
using SportsHubBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using System.Text.Json;

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
        public ActionResult<BannerModel> AddBanner([FromBody] BannerModel model)
        {

            if (model == null)
            {
                return BadRequest("model was null");
            }
            try
            {
                var res = _bannerService.AddBannerFromModel(model);
                return _bannerService.GetBaseBannerModel(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
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
            [FromQuery] bool? IsClosed,
            [FromQuery] int? languageId = null
            )
        {
            var result = _bannerService.GetBanners(categoryId, bannerId, IsClosed);
             try
            {
                IEnumerable<BannerModel> models;

                if (languageId == null)
                {
                    models = result.Select(a => _bannerService.GetBaseBannerModel(a));
                }
                else
                {
                    models = result.Select(sa => _bannerService.GenerateBannerModel(sa, (int)languageId ));
                }
                return Ok(models);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
