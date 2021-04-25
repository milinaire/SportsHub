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
    public class AdvertisingController : ControllerBase
    {
        private readonly IAdvertisingService advertisingService;

        public AdvertisingController(IAdvertisingService advertisingService)
        {
            this.advertisingService = advertisingService;
        }
        [HttpPost]
        public IActionResult AddAdvertising([FromBody]AdvertisingModel model) {
           
            if (model == null)
            {
                return BadRequest("model was null");
            }

            try
            {
                 advertisingService.AddAdvertisingFromModel(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return StatusCode(201);
        }


        [HttpPut("{id}")]

        public IActionResult UpdateAdvertising([FromRoute] int id, AdvertisingModel model) {
            if (model == null)
            {
                return BadRequest("model was null");
            }

            try
            {
                advertisingService.UpdateAdvertisingById(id, model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }
    

      [HttpDelete("{id}")]
        public IActionResult DeleteAdvertising([FromRoute] int id) {

            try
            {
                advertisingService.DeleteAdvertisingById(id);
            }
            catch (ArgumentException)
            {
                return NotFound($"Advertisin with id {id} is not found");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();

            
        }

       

        [HttpPost("categoryad")]
        public IActionResult AddNewCategoryAdFromModel([FromBody] AdvertisingModel model)
        {
            try
            {
                advertisingService.AddNewCategoryAdFromModel(model);
                return Ok($"Advertising {model.AdvertisingId} for category {model.CategoryId} successfully added");
            }
            catch (ArgumentNullException)
            {
                return BadRequest($"Advertising {model.AdvertisingId} was null");
            }
            catch (ArgumentException)
            {
                return BadRequest($"CategoryAd in category {model.CategoryId} for advertising {model.AdvertisingId} already exists");
            }
        }
        [HttpDelete("categoryad")]
        public IActionResult DeleteCategoryAdById([FromQuery] int advertisingId, int categoryId)
        {
            try
            {
                advertisingService.DeleteCategoryAdById(advertisingId, categoryId);
                return Ok($"advertising  {advertisingId} successfully deleted");
            }
            
            catch (ArgumentException)
            {
                return BadRequest($"categoryAd for {advertisingId} in category {categoryId} not found");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("localization")]
        public IActionResult AddNewAdvertisingLocalizationFromModel([FromBody] AdvertisingModel model)
        {
            try
            {
                advertisingService.AddNewAdvertisingLocalizationFromModel(model);
                return Ok($"Advertising {model.AdvertisingId} successfully added");
            }
            catch (ArgumentNullException)
            {
                return BadRequest($"Advertising {model.AdvertisingId} was null");
            }
            catch (ArgumentException)
            {
                return BadRequest($"Localization in language {model.LanguageId} for team {model.AdvertisingId} already exists");
            }
        }

        [HttpPut("localization")]
        public IActionResult UpdateAdvertisingLocalizationFromModel([FromBody] AdvertisingModel model)
        {
            try
            {
                advertisingService.UpdateAdvertisingLocalizationFromModel(model);
                return Ok($"Advertising  {model.AdvertisingId} successfully updated");
            }
            catch (ArgumentNullException)
            {
                return BadRequest($"Advertising {model.AdvertisingId} was null");
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
        public IActionResult DeleteAdvertisingLocalizationById([FromQuery] int advertisingId, int languageId)
        {
            try
            {
                advertisingService.DeleteAdvertisingLocalizationById(advertisingId, languageId);
                return Ok($"advertising  {advertisingId} successfully deleted");
            }

            catch (ArgumentException)
            {
                return BadRequest($"Localization for advertising {advertisingId} in  language {languageId} not found");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}