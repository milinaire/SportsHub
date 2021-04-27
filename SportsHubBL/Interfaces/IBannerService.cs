using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsHubBL.Models;
using SportsHubDAL.Entities;

namespace SportsHubBL.Interfaces
{
    public interface IBannerService
    {
        public void AddBannerFromModel(BannerModel model);
        public void DeleteBannerById(int BannerId);
        public void UpdateBannerById(int id, BannerModel model);
        public void AddNewBannerLocalizationFromModel(BannerModel model);
        public void DeleteBannerLocalizationById(int bannerId, int languageId);
        public void UpdateBannerLocalizationFromModel(BannerModel model);
        public BannerLocalization GetBannerLocalization(int bannerId, int languageId);
        public BannerModel GenerateBannerModel(Banner banner, int languageId);
        public BannerModel GetBannerModel(Banner banner, Language language);
        public IEnumerable<Banner> GetBanners(int? categoryId, int? bannerId, bool? IsClosed);

    }
}
