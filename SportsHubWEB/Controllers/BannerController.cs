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
        [HttpGet("{id}")]
        public ActionResult<BannerModel> GetBannerById([FromRoute] int id)
        {
            int? languageId = 1;
            try
            {
                return bannerService.GenerateBannerModel(bannerService.GetBannerById(id), languageId ?? 1);
            }
            catch (ArgumentException)
            {
                return BadRequest($"Banner with id {id} not found");
            }
        }
        [HttpGet]
        public IEnumerable<BannerModel> GetAllBanner()
        {
            int? languageId = 1;

            return bannerService.GetAllBanner().Select(sa => bannerService.GenerateBannerModel(sa, languageId ?? 1));
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

    }
}
