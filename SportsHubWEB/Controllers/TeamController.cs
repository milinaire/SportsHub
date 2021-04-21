using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsHubBL.Interfaces;
using SportsHubBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using SportsHubDAL.Entities;

namespace SportsHubWEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
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
                var result = _teamService.GetTeams(conferenceId,categoryId,teamId,locationId).Select(sa => _teamService.GenerateTeamModel(sa, locationId ?? 1));
                if(result.IsNullOrEmpty())
                    return NotFound("Teams are not found");
                return Ok(result);
            }
            catch (ArgumentException)
            {
                return BadRequest("Teams are not found");
            }
        }
        [HttpPost]
        public IActionResult AddTeamFromModel([FromBody] TeamModel model)
        {
            try
            {
                _teamService.AddTeamFromModel(model);
                return Ok($"Team {model.TeamId} successfully added");
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
        
        
        [HttpPost("localization")]
        public IActionResult AddNewTeamLocalizationFromModel([FromBody] TeamModel model)
        {
            try
            {
                _teamService.AddNewTeamLocalizationFromModel(model);
                return Ok($"Team {model.TeamId} successfully added");
            }
            catch (ArgumentNullException)
            {
                return BadRequest($"Team {model.TeamId} was null");
            }
            catch (ArgumentException)
            {
                return BadRequest($"Localization in language {model.LanguageId} for team {model.TeamId} already exists");
            }
        }

        [HttpPut]
        public IActionResult UpdateTeamLocalizationFromModel([FromBody] TeamModel model)
        {
            try
            {
                _teamService.UpdateTeamLocalizationFromModel(model);
                return Ok($"Team  {model.TeamId} successfully updated");
            }
            catch (ArgumentNullException)
            {
                return BadRequest($"Team {model.TeamId} was null");
            }
            catch (ArgumentException)
            {
                return BadRequest($"Localization in language {model.LanguageId} for team {model.TeamId} already exists");
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
                _teamService.UpdateTeamFromModel(id, teamModel);
                return Ok($"Team {id} successfully Updated");
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
            
        }
        
        [HttpDelete]
        public IActionResult DeleteTeamLocalizationById([FromQuery] int teamId, int languageId)
        {
            try
            {
                _teamService.DeleteTeamLocalizationById(teamId,  languageId);
                return Ok($"Team  {teamId} successfully deleted");
            }
            catch (ArgumentNullException)
            {
                return BadRequest($"Team {teamId} was null");
            }
            catch (ArgumentException)
            {
                return BadRequest($"Localization in language {languageId} for team {teamId} already exists");
            }
        }
        
    }
}