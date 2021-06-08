using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsHubBL.Interfaces;
using SportsHubBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SportsHubWEB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PhotoOfTheDayController : ControllerBase
    {
        private readonly IPhotoOfTheDayService _photoOfTheDayService;
        private readonly IImageService _imageService;
        private readonly ILanguageService _languageService;

        public PhotoOfTheDayController(IPhotoOfTheDayService photoOfTheDayService, ILanguageService languageService, IImageService imageService)
        {
            _photoOfTheDayService = photoOfTheDayService;
            _languageService = languageService;
            _imageService = imageService;
        }
        [HttpGet]
        public ActionResult<PhotoOfTheDayModel> GetSportsArticles()
        {
            return _photoOfTheDayService.GetPhotoOfTheDay();
        }
        //TODO ADD Requests for photo of the day
    }
}