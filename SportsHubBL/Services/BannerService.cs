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
        private readonly IRepository<Banner> bannerRepository;
        private readonly IRepository<Language> languageRepository;
        private readonly IRepository<Category> categoryRepository;
        private readonly IRepository<Image> imageRepository;
        private readonly INoIdRepository<BannerLocalization> bannerLocalizationRepository;

        public BannerService(
            IRepository<Banner> bannerRepository,
            IRepository<Language> languageRepository,
            IRepository<Category> categoryRepository,
            INoIdRepository<BannerLocalization> bannerLocalizationRepository,
            IRepository<Image> imageRepository
            )
        {
            this.bannerRepository = bannerRepository;
            this.languageRepository = languageRepository;
            this.categoryRepository = categoryRepository;
            this.bannerLocalizationRepository = bannerLocalizationRepository;
            this.imageRepository = imageRepository;
        }
        public void AddBannerFromModel(BannerModel model)
        {
            var banner = GetBannerFromModel(model);

            bannerRepository.Insert(banner);
        }
        private Banner GetBannerFromModel(BannerModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (bannerRepository.Set().Any(a => a.Id == model.BannerId))
            {
                throw new ArgumentException($"banner with id {model.BannerId} is already exist", nameof(model));
            }

            var category = categoryRepository.Set().FirstOrDefault(c => c.Id == model.CategoryId);

            var image = imageRepository.Set().FirstOrDefault(i => i.Id == model.ImageId);

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
            var banner = bannerRepository.Set().FirstOrDefault(a => a.Id == id);

            if (banner == null)
            {
                throw new ArgumentException($"Banner {id} not found", nameof(id));
            }

            bannerRepository.Delete(banner);
        }
        public void UpdateBannerById(int id, BannerModel model)
        {
            var originalBanner = bannerRepository.Set().FirstOrDefault(a => a.Id == id);

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

            bannerRepository.Update(originalBanner);
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
                banner = bannerRepository.Set()
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
            var language = languageRepository.Set().FirstOrDefault(l => l.Id == languageId);

            if (language == null)
            {
                throw new ArgumentException($"language {languageId} not found", nameof(language));
            }
            return this.GetBannerModel(banner, language);
        }
        public void AddNewBannerLocalizationFromModel(BannerModel model)
        {
           

            var bannerLocalization = GetBannerLocalizationFromModel( model);

            if (bannerLocalizationRepository.Set()
                .Any(al => al.BannerId == model.BannerId && al.LanguageId == model.LanguageId))
            {
                throw new ArgumentException($"localization in language {model.LanguageId} for banner {model.BannerId} already exists", nameof(model));
            }

            bannerLocalizationRepository.Insert(bannerLocalization);
        }
        private BannerLocalization GetBannerLocalizationFromModel( BannerModel model)
        {
            var language = languageRepository.Set().FirstOrDefault(l => l.Id == model.LanguageId);

            if (language == null)
            {
                throw new ArgumentException($"can\'t find language {model.LanguageId}", nameof(model));
            }
            var banner = bannerRepository.Set().FirstOrDefault(l => l.Id == model.BannerId);

            if (banner == null)
            {
                throw new ArgumentException($"can\'t find banner  {model.BannerId}", nameof(model));
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
            var bannerLocalization = bannerLocalizationRepository.Set()
                .FirstOrDefault(al => al.BannerId == bannerId && al.LanguageId == languageId);

            if (bannerLocalization == null)
            {
                throw new ArgumentException($"localization for banner {bannerId} in language {languageId} not found");
            }

            bannerLocalizationRepository.Delete(bannerLocalization);
        }
        public void UpdateBannerLocalizationFromModel(BannerModel model)
        {
            
            var originalBannerLocalization = bannerLocalizationRepository.Set()
                .FirstOrDefault(al => al.BannerId == model.BannerId && al.LanguageId == model.LanguageId);

            if (originalBannerLocalization == null)
            {
                throw new ArgumentException($"no previous localization in language {model.LanguageId} of banner {model.BannerId}", nameof(model));
            }

            var newBannerLocalization = GetBannerLocalizationFromModel( model);

            originalBannerLocalization.Headline = newBannerLocalization.Headline;
            bannerLocalizationRepository.Update(originalBannerLocalization);
        }
        public BannerLocalization GetBannerLocalization(int bannerId, int languageId)
        {
            var banner = bannerRepository.Set().FirstOrDefault(a => a.Id == bannerId);
            var language = languageRepository.Set().FirstOrDefault(l => l.Id == languageId);

            if (banner == null|| language == null)
            {
                throw new ArgumentException("banner or language not found", nameof(bannerId));
            }
            return bannerLocalizationRepository.Set().FirstOrDefault(al => al.Banner == banner && al.Language == language);
        }

        public IEnumerable<Banner> GetBanners( int? categoryId, int? bannerId, bool? IsClosed)
        {

            var query = from a in bannerRepository.Set()
                    .Include(sa => sa.Category)
                    .Include(sa => sa.Image)
                        where categoryId == null || a.Category.Id == categoryId && a.IsClosed==false
                        where IsClosed == null || a.IsClosed == IsClosed
                        where bannerId == null || a.Id == bannerId
                        select a;

            return query.ToList();
        }
    }
}
