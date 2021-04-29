using SportsHubDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubBL.Interfaces
{
    public interface ILanguageService
    {
        public int DefaultSiteLanguageId { get; }

        public Language DefaultSiteLanguage { get; }

        public Task SetUserPreferredLanguageAsync(string userId, int languageId);

        public Task<int> GetUserPreferredLanguageAsync(string userId);

        public void AddLanguage(Language language);

        public void UpdateLanguage(int id, Language language);

        public void DeleteLanguage(int id);

        public Language GetLanguage(int id);
    }
}
