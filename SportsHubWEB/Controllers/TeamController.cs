using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsHubBL.Interfaces;
using SportsHubBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        /*[HttpGet]
        public Team GetTeamById([FromQuery]int id)
        {
            // TODO: change this call to use language
            return _teamService.GetTeamById(id);
        }
        */
        
        [HttpGet]
        public IEnumerable<TeamModel> GetTeamsByCategory([FromQuery]int categoryId)
        {
            return _teamService.GetTeamsByCategory(categoryId).Select(a => _teamService.GenerateTeamModel(a, 1));
        }

    }
}