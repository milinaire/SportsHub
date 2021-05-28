using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsHubBL.Interfaces;
using SportsHubBL.Models;
using SportsHubDAL.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsHubWEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreakDownController : ControllerBase
    {
        private readonly IBreakDownService _breakDownService;
        private readonly ILanguageService _languageService;

        public BreakDownController(IBreakDownService breakDownService,
            ILanguageService languageService)
        {
            _breakDownService = breakDownService;
            _languageService = languageService;
        }

        [HttpGet]
        public IEnumerable<BreakDownModel> GetBreakDowns([FromQuery]bool showHidden = false, [FromQuery]int? languageId = null)
        {
            if (languageId == null)
            {
                languageId = _languageService.DefaultSiteLanguageId;
            }

            return _breakDownService.GetBreakDowns((int)languageId, showHidden);
        }

        [HttpPost]
        public ActionResult AddBreakDown([FromBody] BreakDownModel model)
        {
            if (model == null)
            {
                return BadRequest("model was null");
            }

            try
            {
                _breakDownService.AddBreakDown(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBreakDown([FromRoute] int id, [FromBody] BreakDownModel model)
        {
            if (model == null)
            {
                return BadRequest("model was null");
            }

            try
            {
                _breakDownService.UpdateBreakDown(id, model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBreakDown([FromRoute] int id)
        {
            try
            {
                _breakDownService.DeleteBreakDown(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}
