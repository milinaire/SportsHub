using Microsoft.AspNetCore.Identity;
using SportsHubBL.Interfaces;
using SportsHubDAL.Constants;
using SportsHubDAL.Entities;
using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubBL.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly IRepository<Language> _languageRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public LanguageService(IRepository<Language> languageRepository, UserManager<ApplicationUser> userManager)
        {
            _languageRepository = languageRepository;
            _userManager = userManager;
            DefaultSiteLanguageId = GlobalSiteConstants.EnglishLanguageId;
            DefaultSiteLanguage = _languageRepository.GetById(DefaultSiteLanguageId);
        }

        public int DefaultSiteLanguageId { get; }
        public Language DefaultSiteLanguage { get; }

        public void AddLanguage(Language language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(nameof(language));
            }

            _languageRepository.Insert(language);
        }

        public void DeleteLanguage(int id)
        {
            _languageRepository.Delete(_languageRepository.GetById(id));
        }

        public IEnumerable<Language> GetAllLanguages()
        {
            return _languageRepository.Set().ToList();
        }

        public Language GetLanguage(int id)
        {
            return _languageRepository.GetById(id);
        }

        public async Task<int> GetUserPreferredLanguageAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user.PreferredLanguage;
        }

        public async Task SetUserPreferredLanguageAsync(string userId, int languageId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception($"User {userId} not found");
            }

            user.PreferredLanguage = languageId;

            await _userManager.UpdateAsync(user);
        }

        public void UpdateLanguage(int id, Language language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(nameof(language));
            }

            var oldLanguage = _languageRepository.GetById(id);

            if (oldLanguage == null)
            {
                throw new Exception($"language {id} not found");
            }

            oldLanguage.LanguageName = language.LanguageName;

            _languageRepository.Update(oldLanguage);
        }
    }
}
