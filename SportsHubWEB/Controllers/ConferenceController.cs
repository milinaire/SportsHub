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
                //_conferenceService.AddNewConferenceLocalizationFromModel(conferenceModel);
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
    }
}