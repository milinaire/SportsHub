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
        public IActionResult GetAllTeams()
        {
            var result = _teamService.GetAllTeams();
            if(result.IsNullOrEmpty())
                return NotFound("Teams are not found");
            return Ok(result);
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetTeamById([FromQuery]int id)
        {
            try
            {
                var result = _teamService.GetTeamById(id);
                return Ok(result);
            }
            catch (ArgumentException)
            {
                return NotFound($"Team with id {id} is not found");
            }
            
        }
        
        
        [HttpGet("category/{categoryId:int}")]
        public IActionResult GetTeamsByCategory([FromQuery]int categoryId)
        {
            try
            {
                var result = _teamService.GetTeamsByCategory(categoryId).Select(a => _teamService.GenerateTeamModel(a, 1));
                return Ok(result);
            }
            catch (ArgumentException)
            {
                return NotFound($"Teams in category with id {categoryId} are not found");
            }
            
        }
        
        [HttpGet("conference/{conferenceId:int}")]
        public IActionResult GetTeamsByConference([FromQuery]int conferenceId)
        {
            try
            {
                var result = _teamService.GetTeamsByConference(conferenceId).Select(a => _teamService.GenerateTeamModel(a, 1));
                return Ok(result);
            }
            catch (ArgumentException)
            {
                return NotFound($"Teams in category with id {conferenceId} are not found");
            }
            
        }
        
        [HttpGet("location/{locationId:int}")]
        public IActionResult GetTeamsByLocation([FromQuery]int locationId)
        {
            try
            {
                var result = _teamService.GetTeamsByLocation(locationId).Select(a => _teamService.GenerateTeamModel(a, 1));
                return Ok(result);
            }
            catch (ArgumentException)
            {
                return NotFound($"Teams in location with id {locationId} are not found");
            }
            
        }
        [HttpGet("{teamId:int}/{languageId:int}")]
        public IActionResult GetTeamLocalization([FromQuery]int teamId, int languageId)
        {
            try
            {
                var result = _teamService.GetTeamLocalization(teamId,languageId);
                return Ok(result);
            }
            catch (ArgumentException)
            {
                return NotFound($"Teams localization with id {languageId} is not found");
            }
            
        }
        
        
        

    }
}