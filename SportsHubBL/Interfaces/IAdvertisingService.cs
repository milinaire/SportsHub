using SportsHubBL.Models;
using SportsHubDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SportsHubBL.Interfaces
{
     public interface IAdvertisingService
    {
        public void AddAdvertisingFromModel(AdvertisingModel model);
        public void AddNewAdvertisingLocalizationFromModel(AdvertisingModel model);
        public void AddNewCategoryAdFromModel(AdvertisingModel model);
        public void DeleteCategoryAdById(int advertisingId, int categoryId);
        public IEnumerable<CategoryAd> GetCategoryAd(int advertisingId);
        public IEnumerable<Advertising> GetAllAdvertising();
        public Advertising GetAdvertisingById(int id);
        public void DeleteAdvertisingById(int AdvertisingId);
        public void UpdateAdvertisingById(int id, AdvertisingModel model);
        public void DeleteAdvertisingLocalizationById(int advertisingId, int languageId);
        public void UpdateAdvertisingLocalizationFromModel (AdvertisingModel model);
        public AdvertisingLocalization GetAdvertisingLocalization(int advertisingId, int languageId);
        public AdvertisingModel GetAdvertisingModel(Advertising advertising, Language language);
        public AdvertisingModel GenerateAdvertisingModel(Advertising advertising, int languageId);
        public IEnumerable<Advertising> GetAdvertisingByCategory(int categoryId);

    }
}
