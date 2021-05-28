using Microsoft.AspNetCore.Mvc;
using SportsHubBL.Interfaces;
using SportsHubBL.Models;
using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using IdentityServer4.Extensions;
using System.Collections.Generic;
using SportsHubDAL.Entities;

namespace SportsHubWEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILanguageService _languageService;

        public CategoryController(ICategoryService categoryService, ILanguageService languageService)
        {
            _categoryService = categoryService;
            _languageService = languageService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryModel>> GetCategories(
            [FromQuery] int? languageId = null)
        {
            try
            {
                var result = _categoryService.GetCategories(languageId?? _languageService.DefaultSiteLanguageId);
                if(result.IsNullOrEmpty())
                    return NotFound("Categories are not found");
                return Ok(result);
            }
            catch (ArgumentException)
            {
                return BadRequest("Categories are not found");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryModel> GetCategoryById([FromRoute] int id, [FromQuery] int? languageId = null)
        {
            try
            {
                var category = _categoryService.GetCategoryById(id);

                if (category == null)
                {
                    return NotFound();
                }

                return Ok(_categoryService.GenerateCategoryModel(category, languageId?? _languageService.DefaultSiteLanguageId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<CategoryModel> AddCategory([FromBody] CategoryModel model)
        {
            try
            {
                return Ok(_categoryService.GenerateCategoryModel(
                    _categoryService.AddCategoryFromModel(model), model.LanguageId ?? _languageService.DefaultSiteLanguageId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<CategoryModel> UpdateCategory([FromRoute] int id, [FromBody] CategoryModel model)
        {
            if (model == null)
            {
                return BadRequest("model was null");
            }

            try
            {
                var res = _categoryService.UpdateCategoryFromModel(id, model);
                return _categoryService.GenerateCategoryModel(res, model.LanguageId?? _languageService.DefaultSiteLanguageId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory([FromRoute] int id)
        {
            try
            {
                _categoryService.DeleteCategoryById(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/localization")]
        public ActionResult<IEnumerable<CategoryLocalization>> GetCategoryLocalizations([FromRoute] int id)
        {
            try
            {
                return _categoryService.GetAllCategoryLocalizations(id).ToList();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("{id}/localization")]
        public ActionResult<CategoryModel> AddCategoryLocalization([FromRoute] int id, [FromBody] CategoryModel model)
        {
            try
            {
                var res = _categoryService.AddNewCategoryLocalizationFromModel(model);
                return _categoryService.GenerateCategoryModel(_categoryService.GetCategoryById(res.CategoryId), res.LanguageId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/localization/{languageId}")]
        public ActionResult<CategoryLocalization> GetCategoryLocalization([FromRoute] int id, [FromRoute] int languageId)
        {
            try
            {
                var categoryLocalization = _categoryService.GetCategoryLocalization(id, languageId);

                return Content(JsonSerializer.Serialize(categoryLocalization), "application/json");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}/localization/{languageId}")]
        public ActionResult DeleteCategoryLocalization([FromRoute] int id, [FromRoute] int languageId)
        {
            try
            {
                _categoryService.DeleteCategoryLocalizationById(id, languageId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpPut("{id}/localization/{languageId}")]
        public ActionResult<CategoryModel> UpdateCategoryLocalization([FromRoute] int id, [FromRoute] int languageId, [FromBody] CategoryModel model)
        {
            if (model.LanguageId != languageId || model.Id != id)
            {
                return BadRequest("id\'s in the model and in the route have to be identical");
            }

            try
            {

                var res = _categoryService.UpdateCategoryLocalizationFromModel(model);
                return _categoryService.GenerateCategoryModel(_categoryService.GetCategoryById(res.CategoryId), res.LanguageId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}