using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsHubBL.Interfaces;
using SportsHubBL.Models;
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
        public BreakDownController(IBreakDownService breakDownService)
        {
            _breakDownService = breakDownService;
        }

        [HttpGet]
        public IEnumerable<BreakDownModel> GetBreakDowns([FromQuery]bool showHidden = false)
        {
            // TODO: cange this call to use language
            int? languageId = 1;

            return _breakDownService.GetBreakDowns(languageId?? 1/*english*/, showHidden);
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
                throw;
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
