using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportsHubBL.Interfaces;
using SportsHubBL.Models;
using SportsHubDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SportsHubWEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConferenceController : ControllerBase
    {
        private readonly IConferenceService _conferenceService;

        public ConferenceController(
            IConferenceService conferenceService)
        {
            _conferenceService = conferenceService;
        }

        [HttpPost]
        public ActionResult AddConference([FromBody] ConferenceModel conferenceModel)
        {
            if (conferenceModel == null)
            {
                return BadRequest("model was null");
            }
            try
            {
                _conferenceService.AddConferenceFromModel(conferenceModel);
                _conferenceService.AddNewConferenceLocalizationFromModel(conferenceModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateConference([FromRoute] int id, [FromBody] ConferenceModel conferenceModel)
        {
            if (conferenceModel == null)
            {
                return BadRequest("model was null");
            }
            try
            {
                _conferenceService.UpdateConferenceById(id, conferenceModel);
               // _conferenceService.UpdateConferenceLocalizationFromModel(conferenceModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteConference([FromRoute] int id)
        {
            try
            {
                _conferenceService.DeleteConferenceById(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }
        [HttpPost("localization")]
        public IActionResult AddNewConferenceLocalizationFromModel([FromBody] ConferenceModel model)
        {
            if (model == null)
            {
                return BadRequest("model was null");
            }
            try
            {
                _conferenceService.AddNewConferenceLocalizationFromModel(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return StatusCode(201);
        }
        [HttpDelete("localization")]
        public ActionResult DeleteConferenceLocalization([FromQuery] int conferenceId,int languageId)
        {
            try
            {
                _conferenceService.DeleteConferenceLocalizationById(conferenceId, languageId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        [HttpGet]
        public IEnumerable<ConferenceModel> GetSConferences([FromQuery] bool?show, int? categoryId)
        {
            int? languageId = 1;

            return _conferenceService.GetConferences(show,categoryId)
                .Select(sa => _conferenceService.GenerateConferenceModel(sa, languageId ?? 1));
        }
    }
}