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
        private readonly IBannerService bannerService;

        public BannerController(IBannerService bannerService)
        {
            this.bannerService = bannerService;
        }
        [HttpPost]
        public IActionResult AddBanner([FromBody] BannerModel model)
        {

            if (model == null)
            {
                return BadRequest("model was null");
            }
            try
            {
                bannerService.AddBannerFromModel(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return StatusCode(201);
        }


        [HttpPut("{id}")]

        public IActionResult UpdateBanner([FromRoute] int id, BannerModel model)
        {
            if (model == null)
            {
                return BadRequest("model was null");
            }
            try
            {
                bannerService.UpdateBannerById(id, model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBanner([FromRoute] int id)
        {
            try
            {
                bannerService.DeleteBannerById(id);
            }
            catch (ArgumentException)
            {
                return NotFound($"Banner with id {id} is not found");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
        [HttpPost("localization")]
        public IActionResult AddNewBannerLocalizationFromModel([FromBody] BannerModel model)
        {
            try
            {
                bannerService.AddNewBannerLocalizationFromModel(model);
                return Ok($"Banner {model.BannerId} successfully added");
            }
            catch (ArgumentNullException)
            {
                return BadRequest($"Banner {model.BannerId} was null");
            }
            catch (ArgumentException)
            {
                return BadRequest($"Localization in language {model.LanguageId} for banner {model.BannerId} already exists");
            }
        }

        [HttpGet]
        public IActionResult GetBanners
            (
            [FromQuery] int? categoryId,
            [FromQuery] int? bannerId,
            [FromQuery] bool? IsClosed
            )
        {
            int? languageId = 1;
            try
            {
                var result = bannerService.GetBanners( categoryId, bannerId, IsClosed).Select(sa => bannerService.GenerateBannerModel(sa, languageId ?? 1));
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
        public IActionResult UpdateBannerLocalizationFromModel([FromBody] BannerModel model)
        {
            try
            {
                bannerService.UpdateBannerLocalizationFromModel(model);
                return Ok($"Banner  {model.BannerId} successfully updated");
            }
            catch (ArgumentNullException)
            {
                return BadRequest($"Banner {model.BannerId} was null");
            }
            catch (ArgumentException)
            {
                return BadRequest($"Localization not found");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("localization")]
        public IActionResult DeleteBannerLocalizationById([FromQuery] int BannerId, int languageId)
        {
            try
            {
                bannerService.DeleteBannerLocalizationById(BannerId, languageId);
                return Ok($"Banner  {BannerId} successfully deleted");
            }

            catch (ArgumentException)
            {
                return BadRequest($"Localization for Banner {BannerId} in  language {languageId} not found");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
