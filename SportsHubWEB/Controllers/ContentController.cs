using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsHubBL.Enums;
using SportsHubBL.Interfaces;
using SportsHubBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsHubWEB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpGet("types")]
        public ActionResult GetContentItemType()
        {
            var dict = new Dictionary<int, string>();

            foreach (var item in Enum.GetValues(typeof(ContentItemType)))
            {
                dict.Add((int)item, Enum.GetName(typeof(ContentItemType), item));
            }

            return Ok(dict);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContentModel>> GetAllContent()
        {
            try
            {
                return Ok(_contentService.GetAllContent().Select(c => _contentService.GetBaseContentModel(c)));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ContentModel> GetContentById([FromRoute] int id)
        {
            try
            {
                return _contentService.GetBaseContentModel(_contentService.GetContentById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{contentItemType}/{itemId}")]
        public ActionResult<ContentModel> GetItemContent([FromRoute] string contentItemType, [FromRoute] int itemId)
        {
            try
            {
                var type = (ContentItemType)Enum.Parse(typeof(ContentItemType), contentItemType);
                return _contentService.GetContentModel(itemId, type);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{contentItemType}/{itemId}")]
        public ActionResult<ContentModel> UpdateItemContent([FromRoute] string contentItemType, [FromRoute] int itemId, [FromBody] ContentModel model)
        {
            try
            {
                var type = (ContentItemType)Enum.Parse(typeof(ContentItemType), contentItemType);
                var content = _contentService.UpdateContentFromModel(model, itemId, type);
                return Ok(_contentService.GetBaseContentModel(content));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{contentItemType}/{itemId}")]
        public ActionResult DeleteItemContent([FromRoute] string contentItemType, [FromRoute] int itemId)
        {
            try
            {
                var type = (ContentItemType)Enum.Parse(typeof(ContentItemType), contentItemType);
                _contentService.DeleteContentFromItem(itemId, type);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("{contentItemType}/{itemId}")]
        public ActionResult AddItemContent([FromRoute] string contentItemType, [FromRoute] int itemId, [FromBody] ContentModel model)
        {
            try
            {
                var type = (ContentItemType)Enum.Parse(typeof(ContentItemType), contentItemType);
                var content = _contentService.AddContentFromModel(model, itemId, type);
                return Ok(_contentService.GetBaseContentModel(content));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
