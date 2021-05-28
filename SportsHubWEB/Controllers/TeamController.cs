using Microsoft.AspNetCore.Mvc;
using SportsHubBL.Interfaces;
using SportsHubBL.Models;
using System;
using System.Linq;
using IdentityServer4.Extensions;
using SportsHubDAL.Entities;
using System.Text.Json;

namespace SportsHubWEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly ILanguageService _languageService;
        public TeamController(ITeamService teamService, ILanguageService languageService)
        {
            _teamService = teamService;
            _languageService = languageService;
        }
        
        
        
        [HttpGet]
        public IActionResult GetTeams
            (
            [FromQuery] int? conferenceId,
            [FromQuery] int? categoryId,
            [FromQuery] int? teamId,
            [FromQuery] int? locationId
            )
        {
            try
            {
                var result = _teamService.GetTeams(conferenceId,categoryId,teamId,locationId)
                    .Select(sa => _teamService.GenerateTeamModel(sa, locationId ?? 1));
                if(result.IsNullOrEmpty())
                    return NotFound("Teams are not found");
                return Ok(result);
            }
            catch (ArgumentException)
            {
                return BadRequest("Teams are not found");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public IActionResult AddTeamFromModel([FromBody] TeamModel model)
        {
            try
            {
                var res = _teamService.AddTeamFromModel(model);
                return Content(JsonSerializer.Serialize(_teamService.GetModel(res)), "application/json");
            }
            catch (ArgumentNullException)
            {
                return BadRequest($"Team {model.TeamId} was null");
            }
            catch (ArgumentException)
            {
                return BadRequest($"Team id {model.TeamId} is already taken");
            }

        }
        
        [HttpPut("{id:int}")]
        public IActionResult UpdateTeamFromModel([FromRoute] int id, [FromBody] TeamModel teamModel)
        {
            try
            {
                if (teamModel == null)
                {
                    return BadRequest("Model was null");
                }
                var res = _teamService.UpdateTeamFromModel(id, teamModel);
                return Content(JsonSerializer.Serialize(_teamService.GetModel(res)), "application/json");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult DeleteTeamById([FromRoute]int id)
        {
            try
            {
                _teamService.DeleteTeamById(id);
                return Ok($"Team {id} successfully deleted");
            }
            catch (ArgumentException)
            {
                return NotFound($"Team with id {id} is not found");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet("{id:int}/localization/{languageId:int}")]
        public ActionResult<TeamLocalization> GetTeamLocalization([FromRoute] int id, [FromRoute] int languageId)
        {
            try
            {
                var teamLocalization = _teamService.GetTeamLocalization(id, languageId);
                
                return Content(JsonSerializer.Serialize(teamLocalization), "application/json");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost("{id:int}/localization/{languageId:int}")]
        public ActionResult AddNewTeamLocalizationFromModel([FromRoute] int id, [FromRoute] int languageId, [FromBody] TeamModel model)
        {
            try
            {
                var res  = _teamService.AddNewTeamLocalizationFromModel(model);
                return  Content(JsonSerializer.Serialize(_teamService.GetModelLocalization(res)), "application/json");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPut("{id:int}/localization/{languageId:int}")]
        public ActionResult UpdateTeamLocalization([FromRoute] int id, [FromRoute] int languageId, [FromBody] TeamModel model)
        {
            if (model.LanguageId != languageId || model.TeamId != id)
            {
                return BadRequest("id\'s in the model and in the route have to be identical");
            }

            try
            {
                _teamService.UpdateTeamLocalizationFromModel(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id:int}/localization/{languageId:int}")]
        public ActionResult DeleteTeamLocalization([FromRoute] int id, [FromRoute] int languageId)
        {
            try
            {
                _teamService.DeleteTeamLocalizationById(id, languageId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
            return Ok();
        }
        
    }
}