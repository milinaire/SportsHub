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
using System.Globalization;

namespace SportsHubBL.Services
{
    public class BannerService : IBannerService
    {
        private readonly IRepository<Banner> _bannerRepository;
        private readonly IRepository<Language> _languageRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Image> _imageRepository;
        private readonly INoIdRepository<BannerLocalization> _bannerLocalizationRepository;

        public BannerService(
            IRepository<Banner> bannerRepository,
            IRepository<Language> languageRepository,
            IRepository<Category> categoryRepository,
            INoIdRepository<BannerLocalization> bannerLocalizationRepository,
            IRepository<Image> imageRepository
            )
        {
            _bannerRepository = bannerRepository;
            _languageRepository = languageRepository;
            _categoryRepository = categoryRepository;
            _bannerLocalizationRepository = bannerLocalizationRepository;
            _imageRepository = imageRepository;
        }
        public Banner AddBannerFromModel(BannerModel model)
        {
            var banner = GetBannerFromModel(model);

            _bannerRepository.Insert(banner);
            return banner;
        }
        private Banner GetBannerFromModel(BannerModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_bannerRepository.Set().Any(a => a.Id == model.BannerId))
            {
                throw new ArgumentException($"banner with id {model.BannerId} is already exist", nameof(model));
            }

            var category = _categoryRepository.Set().FirstOrDefault(c => c.Id == model.CategoryId);

            var image = _imageRepository.Set().FirstOrDefault(i => i.Id == model.ImageId);

            if (image == null && model.ImageUri != default)
            {
                image = new Image
                {
                    Uri = model.ImageUri
                };
            }
            
            return new Banner
            {
                Image = image,
                Category = category,
                IsPublished = (bool)model.IsPublished,
                LastUpdateDate = DateTime.Now,
                IsClosed = (bool)model.IsClosed
            };
        }
        public void DeleteBannerById(int id)
        {
            var banner = _bannerRepository.Set().FirstOrDefault(a => a.Id == id);

            if (banner == null)
            {
                throw new ArgumentException($"Banner {id} not found", nameof(id));
            }

            _bannerRepository.Delete(banner);
        }
        public void UpdateBannerById(int id, BannerModel model)
        {
            var originalBanner = _bannerRepository.Set().FirstOrDefault(a => a.Id == id);

            if (originalBanner == null)
            {
                throw new ArgumentException($"can\'t find banner {id}", nameof(id));
            }

            var banner = GetBannerFromModel(model);


            originalBanner.Image = banner.Image;
            originalBanner.Category = banner.Category;
            originalBanner.LastUpdateDate = DateTime.Now;
            originalBanner.IsClosed = banner.IsClosed;
            originalBanner.IsPublished = banner.IsPublished;

            _bannerRepository.Update(originalBanner);
        }
        public BannerModel GetBannerModel(Banner banner, Language language)
        {
            if (banner == null)
            {
                throw new ArgumentNullException(nameof(banner));
            }

            if (language == null)
            {
                throw new ArgumentNullException(nameof(language));
            }

            if (banner.Image == null || banner.BannerLocalizations == null || banner.Category == null)
            {
                banner = _bannerRepository.Set()
                    .Include(a => a.Image)
                    .Include(a => a.BannerLocalizations)
                    .Include(a => a.Category)
                    .FirstOrDefault(a => a == banner);

                if (banner == null)
                {
                    throw new ArgumentNullException(nameof(banner));
                }
            }

            var bannerLocalization = banner.BannerLocalizations.FirstOrDefault(at => at.Language == language);
            if (bannerLocalization == null)
            {
                throw new ArgumentException("can\'t find localization for banner");
            }
            

            return new BannerModel
            {
                BannerId = banner.Id,
                ImageId = banner.Image.Id,
                ImageUri = banner.Image.Uri,
                CategoryId = banner.Category.Id,
                IsPublished = banner.IsPublished,
                IsClosed = banner.IsClosed,
                LastUpdateDate = banner.LastUpdateDate,
                LanguageId = bannerLocalization?.LanguageId ?? default,
                Headline = bannerLocalization?.Headline
            };

        }

        public BannerModel GenerateBannerModel(Banner banner, int languageId)
        {
            var language = _languageRepository.Set().FirstOrDefault(l => l.Id == languageId);

            if (language == null)
            {
                throw new ArgumentException($"language {languageId} not found", nameof(language));
            }
            return this.GetBannerModel(banner, language);
        }
        public void AddNewBannerLocalizationFromModel(BannerModel model)
        {

            var banner = GetBannerById(model.BannerId);
            var bannerLocalization = GetBannerLocalizationFromModel( banner,model);

            if (_bannerLocalizationRepository.Set()
                .Any(al => al.BannerId == model.BannerId && al.LanguageId == model.LanguageId))
            {
                throw new ArgumentException($"localization in language {model.LanguageId} for banner {model.BannerId} already exists", nameof(model));
            }

            _bannerLocalizationRepository.Insert(bannerLocalization);
        }
        public Banner GetBannerById(int id)
        {
            var banner = _bannerRepository.Set().FirstOrDefault(a => a.Id == id);

            return banner;
        }
        private BannerLocalization GetBannerLocalizationFromModel( Banner banner,BannerModel model)
        {
            var language = _languageRepository.Set().FirstOrDefault(l => l.Id == model.LanguageId);

            if (language == null)
            {
                throw new ArgumentException($"can\'t find language {model.LanguageId}", nameof(model));
            }
            

            return new BannerLocalization
            {
                Banner = banner,
                Language = language,
                Headline = model.Headline
            };
        }
        public void DeleteBannerLocalizationById(int bannerId, int languageId)
        {
            var bannerLocalization = _bannerLocalizationRepository.Set()
                .FirstOrDefault(al => al.BannerId == bannerId && al.LanguageId == languageId);

            if (bannerLocalization == null)
            {
                throw new ArgumentException($"localization for banner {bannerId} in language {languageId} not found");
            }

            _bannerLocalizationRepository.Delete(bannerLocalization);
        }
        public void UpdateBannerLocalizationFromModel(BannerModel model)
        {
            var banner = GetBannerById(model.BannerId);
            var originalBannerLocalization = _bannerLocalizationRepository.Set()
                .FirstOrDefault(al => al.BannerId == model.BannerId && al.LanguageId == model.LanguageId);

            if (originalBannerLocalization == null)
            {
                throw new ArgumentException($"no previous localization in language {model.LanguageId} of banner {model.BannerId}", nameof(model));
            }

            var newBannerLocalization = GetBannerLocalizationFromModel( banner,model);

            originalBannerLocalization.Headline = newBannerLocalization.Headline;
            _bannerLocalizationRepository.Update(originalBannerLocalization);
        }
        public BannerLocalization GetBannerLocalization(int bannerId, int languageId)
        {
            var banner = _bannerRepository.Set().FirstOrDefault(a => a.Id == bannerId);
            var language = _languageRepository.Set().FirstOrDefault(l => l.Id == languageId);

            if (banner == null|| language == null)
            {
                throw new ArgumentException("banner or language not found", nameof(bannerId));
            }
            return _bannerLocalizationRepository.Set().FirstOrDefault(al => al.Banner == banner && al.Language == language);
        }

        public IEnumerable<Banner> GetBanners( int? categoryId, int? bannerId, bool? IsClosed)
        {

            var query = from a in _bannerRepository.Set()
                    .Include(sa => sa.Category)
                    .Include(sa => sa.Image)
                        where categoryId == null || a.Category.Id == categoryId && a.IsClosed==false
                        where IsClosed == null || a.IsClosed == IsClosed
                        where bannerId == null || a.Id == bannerId
                        select a;

            return query.ToList();
        }
        private BannerModel FormBaseBannerModel(Banner banner)
        {
            if (banner == null)
            {
                throw new ArgumentNullException(nameof(banner));
            }

            if (banner.Category == null
                || banner.Image == null
                || banner.BannerLocalizations == null)
            {
                banner = _bannerRepository.Set()
                    .Include(a => a.Category)
                    .Include(a => a.Image)
                    .Include(a => a.BannerLocalizations)
                    .FirstOrDefault(a => a == banner);

                if (banner == null)
                {
                    throw new ArgumentNullException(nameof(banner));
                }
            }

            return new BannerModel
            {
                BannerId = banner.Id,
                ImageId = banner.Image?.Id,
                ImageUri = banner.Image?.Uri,
                CategoryId = banner.Category?.Id,
                IsPublished = banner.IsPublished,
                IsClosed = banner.IsClosed,
                LastUpdateDate = banner.LastUpdateDate,
            };
        }

        public BannerModel GetBaseBannerModel(Banner banner)
        {
            if (banner == null)
            {
                throw new ArgumentNullException(nameof(banner));
            }

            var model = FormBaseBannerModel(banner);

            return model;
        }
        
    }
}
