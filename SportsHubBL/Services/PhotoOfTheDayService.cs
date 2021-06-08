using System;
using System.Linq;
using SportsHubBL.Interfaces;
using SportsHubDAL.Entities;
using SportsHubDAL.Interfaces;
using SportsHubBL.Models;
namespace SportsHubBL.Services
{
    public class PhotoOfTheDayService : IPhotoOfTheDayService
    {
        private readonly IRepository<Image> _imageRepository;
        private readonly IImageService _imageService;

        private readonly INoIdRepository<PhotoOfTheDayLocalization> _photoOfTheDayLocalizationRepository;

        public PhotoOfTheDayService(IRepository<Image> imageRepository,
            INoIdRepository<PhotoOfTheDayLocalization> photoOfTheDayLocalizationRepository, IImageService imageService)
        {
            _imageRepository = imageRepository;
            _photoOfTheDayLocalizationRepository = photoOfTheDayLocalizationRepository;
            _imageService = imageService;
        }
        
        //TODO Implement Methods and Create of Find where to store PhotoOfTheDay (we don`t have table)
        //now it is being stored in Localization => we don't have localization for this shit

        public PhotoOfTheDayModel GetPhotoOfTheDay()
        {
            var photoOfTheDay = _photoOfTheDayLocalizationRepository.Set().FirstOrDefault();
            if (photoOfTheDay == null)
            {
                throw new Exception("Photo was null");
            }
            var image = _imageService.GetImageById(photoOfTheDay.PhotoOfTheDayId);
            if (photoOfTheDay == null)
            {
                throw new Exception("No image with such id as in photo of the day");
            }

            return new PhotoOfTheDayModel()
            {
                Id = photoOfTheDay.PhotoOfTheDayId,
                ImageUri = image.Uri,
                Alt = photoOfTheDay.PhotoOfTheDayAlt,
                Title = photoOfTheDay.PhotoOfTheDayTitle,
                Description = photoOfTheDay.PhotoOfTheDayDesciption,
                Author = photoOfTheDay.PhotoOfTheDayAuthor,
                LanguageId = photoOfTheDay.LanguageId
            };
        }

        public PhotoOfTheDayModel UpdatePhotoOfTheDay(PhotoOfTheDayModel model)
        {
            var photoOfTheDay = _photoOfTheDayLocalizationRepository.Set().FirstOrDefault();
            if (photoOfTheDay == null)
            {
                throw new Exception("Photo was null");
            }
            var image = _imageService.GetImageById(photoOfTheDay.PhotoOfTheDayId);
            if (photoOfTheDay == null)
            {
                throw new Exception("No image with such id as in photo of the day");
            }

            _imageService.UpdateImageById(image.Id, model.ImageUri);

            photoOfTheDay.PhotoOfTheDayAlt = model.Alt ?? photoOfTheDay.PhotoOfTheDayAlt;
            photoOfTheDay.PhotoOfTheDayAuthor = model.Author ?? photoOfTheDay.PhotoOfTheDayAuthor;
            photoOfTheDay.PhotoOfTheDayDesciption = model.Description ?? photoOfTheDay.PhotoOfTheDayDesciption;
            photoOfTheDay.PhotoOfTheDayTitle = model.Title ?? photoOfTheDay.PhotoOfTheDayTitle;
            photoOfTheDay.PhotoOfTheDayId = model.Id ?? photoOfTheDay.PhotoOfTheDayId;
            _photoOfTheDayLocalizationRepository.Update(photoOfTheDay);

            return GetPhotoOfTheDay();
        }

        public void DeletePhotoOfTheDay()
        {
            throw new NotImplementedException();
        }
    }
}