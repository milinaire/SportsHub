using SportsHubBL.Interfaces;
using SportsHubBL.Models;
using SportsHubDAL.Entities;
using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace SportsHubBL.Services
{

    public class AdvertisingService : IAdvertisingService
    {
        private readonly IRepository<Advertising> advertisingRepository;
        private readonly IRepository<Language> languageRepository;
        private readonly IRepository<Image> imageRepository;
        private readonly INoIdRepository<AdvertisingLocalization> advertisingLocalizationRepository;
        private readonly INoIdRepository<CategoryAd> categoryAdRepository;
        private readonly INoIdRepository<Category> categoryRepository;

        public AdvertisingService(
            IRepository<Advertising> advertisingRepository,
            IRepository<Language> languageRepository,
            INoIdRepository<AdvertisingLocalization> advertisingLocalizationRepository,
            IRepository<Image> imageRepository,
            INoIdRepository<CategoryAd> categoryAdRepository,
             INoIdRepository<Category> categoryRepository
            )
        {
            this.advertisingRepository = advertisingRepository;
            this.languageRepository = languageRepository;
            this.advertisingLocalizationRepository = advertisingLocalizationRepository;
            this.imageRepository = imageRepository;
            this.categoryAdRepository = categoryAdRepository;
            this.categoryRepository = categoryRepository;
        }
        
        public void DeleteAdvertisingLocalizationById(int advertisingId, int languageId)
        {
            var advertisingLocalization = advertisingLocalizationRepository.Set()
                .FirstOrDefault(al => al.AdvertisingId == advertisingId && al.LanguageId == languageId);

            if (advertisingLocalization == null)
            {
                throw new ArgumentException($"localization for advertising {advertisingId} in language {languageId} not found");
            }

            advertisingLocalizationRepository.Delete(advertisingLocalization);
        }
        public void UpdateAdvertisingLocalizationFromModel(AdvertisingModel model)
        {
            var originalAdvertisingLocalization = advertisingLocalizationRepository.Set()
                .FirstOrDefault(al => al.AdvertisingId == model.AdvertisingId && al.LanguageId == model.LanguageId);

            if (originalAdvertisingLocalization == null)
            {
                throw new ArgumentException($"no localization in language {model.LanguageId} of advertising {model.AdvertisingId}", nameof(model));
            }

            var newAdvertisingLocalization = GetAdvertisingLocalizationFromModel( model);

            originalAdvertisingLocalization.Headline = newAdvertisingLocalization.Headline;

            advertisingLocalizationRepository.Update(originalAdvertisingLocalization);
        }
        public AdvertisingLocalization GetAdvertisingLocalization(int advertisingId, int languageId)
        {
            var advertising = advertisingRepository.Set().FirstOrDefault(a => a.Id == advertisingId);

            if (advertising == null)
            {
                throw new ArgumentException("advertising was null", nameof(advertisingId));
            }

            var language = languageRepository.Set().FirstOrDefault(l => l.Id == languageId);

            if (language == null)
            {
                throw new ArgumentException("language was null", nameof(languageId));
            }

            return advertisingLocalizationRepository.Set().FirstOrDefault(al => al.Advertising == advertising && al.Language == language) ;

        }
        private AdvertisingLocalization GetAdvertisingLocalizationFromModel(AdvertisingModel model)
        {
            var language = languageRepository.Set().FirstOrDefault(l => l.Id == model.LanguageId);

            if (language == null)
            {
                throw new ArgumentException($"can\'t find language {model.LanguageId}", nameof(model));
            }

            var advertising = advertisingRepository.Set().FirstOrDefault(l => l.Id == model.AdvertisingId);

            if (advertising == null)
            {
                throw new ArgumentException($"can\'t find advertising {model.AdvertisingId}", nameof(model));
            }


            return new AdvertisingLocalization
            {
                Advertising = advertising,
                Language = language,
                Headline = model.Headline
            };
        }
        public void AddNewAdvertisingLocalizationFromModel(AdvertisingModel model)
        {

            var advertisingLocalization = GetAdvertisingLocalizationFromModel( model);

            if (advertisingLocalizationRepository.Set()
                .Any(al => al.AdvertisingId == model.AdvertisingId && al.LanguageId == model.LanguageId))
            {
                throw new ArgumentException($"localization in language {model.LanguageId} for advertising {model.AdvertisingId} already exists", nameof(model));
            }

            advertisingLocalizationRepository.Insert(advertisingLocalization);
        }
        public void AddNewCategoryAdFromModel(AdvertisingModel model)
        {

            var categoryAd = GetCategoryAdFromModel( model);

            if (categoryAdRepository.Set()
                .Any(al => al.AdvertisingId == model.AdvertisingId && al.CategoryId == model.CategoryId))
            {
                throw new ArgumentException($"CategoryAd in category {model.CategoryId} for advertising {model.AdvertisingId} already exists", nameof(model));
            }

            categoryAdRepository.Insert(categoryAd);
        }
        public void DeleteCategoryAdById(int advertisingId, int categoryId)
        {
            var categoryAd = categoryAdRepository.Set()
                .FirstOrDefault(al => al.AdvertisingId == advertisingId && al.CategoryId == categoryId);

            if (categoryAd == null)
            {
                throw new ArgumentException($"categoryAd for {advertisingId} in category {categoryId} not found");
            }

            categoryAdRepository.Delete(categoryAd);
        }
        private CategoryAd GetCategoryAdFromModel( AdvertisingModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var category = categoryRepository.Set().FirstOrDefault(l => l.Id == model.CategoryId);
            var advertising = advertisingRepository.Set().FirstOrDefault(l => l.Id == model.AdvertisingId);

            if (category == null || advertising==null)
            {
                throw new ArgumentException($"can\'t find category {model.CategoryId} or advertising {model.AdvertisingId}"  , nameof(model));
            }
            
            return new CategoryAd
            {
                Advertising = advertising,
                Category = category,
                Displayed = model.Displayed,
                Opened = model.Opened
            };
        }
        public IEnumerable<CategoryAd> GetCategoryAd(int advertisingId)
        {
            var advertising = advertisingRepository.Set().FirstOrDefault(a => a.Id == advertisingId);

            if (advertising == null)
            {
                throw new ArgumentException("advertising was null", nameof(advertisingId));
            }

            return categoryAdRepository.Set().Where(al => al.AdvertisingId == advertisingId);


        }
        public IEnumerable<Advertising> GetAllAdvertising()
        {
            try
            {
                return (advertisingRepository.Set().Where(a => a != null));
            }
            catch
            {
                throw new ArgumentException("advertising were null", nameof(advertisingRepository));
            }

        }
        public Advertising GetAdvertisingById(int AdvertisingId)
        {
            var advertising = advertisingRepository.Set().FirstOrDefault(a => a.Id == AdvertisingId);
            if (advertising == null)
            {
                throw new ArgumentException($"advertising with Id = { AdvertisingId} not found", nameof(AdvertisingId));
            }

            return advertising;
        }
        public void DeleteAdvertisingById(int AdvertisingId)
        {
            var advertising = advertisingRepository.Set().FirstOrDefault(a => a.Id == AdvertisingId);
            if (advertising == null)
            {
                throw new ArgumentException($"advertising with Id = { AdvertisingId} not found", nameof(AdvertisingId));
            }
            advertisingRepository.Delete(advertising);
        }
        public void UpdateAdvertisingById(int id, AdvertisingModel model)
        {
            var originalAdvertising = advertisingRepository.Set().FirstOrDefault(a => a.Id == id);

            if (originalAdvertising == null)
            {
                throw new ArgumentException($"can\'t find advertising {id}", nameof(id));
            }

            var advertising = GetAdvertisingFromModel(model);


            originalAdvertising.Image = advertising.Image;
            originalAdvertising.Url = advertising.Url;
            originalAdvertising.IsActive = advertising.IsActive;
            originalAdvertising.DateCreated = advertising.DateCreated;

            advertisingRepository.Update(originalAdvertising);
        }
        public void AddAdvertisingFromModel(AdvertisingModel model)
        {
            var advertising = GetAdvertisingFromModel(model);

            advertisingRepository.Insert(advertising);

        }
        private Advertising GetAdvertisingFromModel(AdvertisingModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (advertisingRepository.Set().Any(a => a.Id == model.AdvertisingId))
            {
                throw new ArgumentException($"Advertising id {model.AdvertisingId} is already taken", nameof(model));
            }


            var image = imageRepository.Set().FirstOrDefault(i => i.Id == model.ImageId);

            if (image == null && model.ImageUri != default)
            {
                image = new Image
                {
                    Uri = model.ImageUri
                };
            }

            return new Advertising
            {
                Image = image,
                IsActive = (bool)model.IsActive,
                Url = model.Url,
                DateCreated = (DateTime)model.DateCreated
            };
        }
        public AdvertisingModel GetAdvertisingModel(Advertising advertising, Language language)
        {
            if (advertising == null)
            {
                throw new ArgumentNullException(nameof(advertising));
            }

            if (language == null)
            {
                throw new ArgumentNullException(nameof(language));
            }

            if (advertising.Image == null || advertising.AdvertisingLocalizations==null )
            {
                advertising = advertisingRepository.Set()
                    .Include(a => a.Image)
                    .Include(a => a.AdvertisingLocalizations)
                    .Include(a => a.CategoryAds)
                    .FirstOrDefault(a => a == advertising);

                if (advertising == null)
                {
                    throw new ArgumentNullException(nameof(advertising));
                }
            }

            var advertisingLocalization = advertising.AdvertisingLocalizations.FirstOrDefault(at => at.Language == language);
            if (advertisingLocalization == null)
            {
                throw new ArgumentException("can\'t find localization for advertising");
            }
            var categoryAd = advertising.CategoryAds.FirstOrDefault(at => at.AdvertisingId == advertising.Id);
            
                return new AdvertisingModel
                {
                    AdvertisingId = advertising.Id,
                    ImageId = advertising.Image.Id,
                    ImageUri = advertising.Image.Uri,
                    Url = advertising.Url,
                    DateCreated = advertising.DateCreated,
                    IsActive = advertising.IsActive,
                    LanguageId = advertisingLocalization?.LanguageId ?? default,
                    CategoryId = categoryAd?.CategoryId ?? 0,
                    Opened = categoryAd?.Opened ?? 0,
                    Displayed = categoryAd?.Displayed ?? 0,
                    Headline = advertisingLocalization?.Headline
                };
            
        }
      
        public AdvertisingModel GenerateAdvertisingModel(Advertising advertising, int languageId)
        {
            var language = languageRepository.Set().FirstOrDefault(l => l.Id == languageId);

            if (language == null)
            {
                throw new ArgumentException($"language {languageId} not found", nameof(language));
            }
            return this.GetAdvertisingModel(advertising, language);
        }


        public IEnumerable<Advertising> GetAdvertisingByCategory(int categoryId)
        {
            var category = categoryRepository.Set().Where(c => c.Id == categoryId);
            if (category == null)
            {
                throw new ArgumentException("category was null", nameof(categoryId));
            }
            var query = advertisingRepository.Set()
                    .Include(sa => sa.CategoryAds).Where(a => a.CategoryAds.Any(a => a.CategoryId == categoryId));
            return query.Where(a=>a.IsActive==true);
        }   

    }
}