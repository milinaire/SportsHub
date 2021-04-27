using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsHubBL.Interfaces;
using SportsHubBL.Models;
using SportsHubDAL.Entities;
using SportsHubDAL.Interfaces;

namespace SportsHubBL.Services
{
    public class ConferenceService : IConferenceService
    {
        private readonly IRepository<Conference> _conferenceRepository;
        private readonly IRepository<Language> _languageRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly INoIdRepository<ConferenceLocalization> _conferenceLocalizationRepository;

        public ConferenceService(
            IRepository<Conference> conferenceRepository,
            IRepository<Language> languageRepository,
            INoIdRepository<ConferenceLocalization> conferenceLocalizationRepository,
            IRepository<Category> categoryRepository
            )
        {
            _conferenceRepository = conferenceRepository;
            _languageRepository = languageRepository;
            _conferenceLocalizationRepository = conferenceLocalizationRepository;
            _categoryRepository = categoryRepository;
        }
        private Conference GetConferenceFromModel(ConferenceModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (_conferenceRepository.Set().Any(a => a.Id == model.ConferenceId))
            {
                throw new ArgumentException($"Conference id {model.ConferenceId} is already taken", nameof(model));
            }
            var category = _categoryRepository.Set().FirstOrDefault(c => c.Id == model.CategoryId);
            if (category==null)
            {
                throw new ArgumentException($"Category {model.CategoryId} not found", nameof(model));
            }
            return new Conference
            {
                Category = category,
                Show = (bool)model.Show
            };
        }
        public void AddConferenceFromModel(ConferenceModel model)
        {
            var conference = GetConferenceFromModel(model);

            _conferenceRepository.Insert(conference);

        }
        public Conference GetConferenceById(int id)
        {
            var conference = _conferenceRepository.Set().FirstOrDefault(a => a.Id == id);
            return conference;
        }
        public void DeleteConferenceById(int id)
        {
            var conference = _conferenceRepository.Set().FirstOrDefault(a => a.Id == id);

            if (conference == null)
            {
                throw new Exception($"Conference {id} not found");
            }

            _conferenceRepository.Delete(conference);
        }
        public void UpdateConferenceById(int id, ConferenceModel model)
        {
            var originalConference = _conferenceRepository.Set().FirstOrDefault(a => a.Id == id);

            if (originalConference == null)
            {
                throw new Exception($"can\'t find conference {id}");
            }
            var conference = GetConferenceFromModel(model);

            originalConference.Category = conference.Category;
            originalConference.Show= conference.Show;

            _conferenceRepository.Update(originalConference);
        }

        private ConferenceLocalization GetConferenceLocalizationFromModel(Conference conference, ConferenceModel model)
        {
            var language = _languageRepository.Set().FirstOrDefault(l => l.Id == model.LanguageId);

            if (language == null)
            {
                throw new Exception($"can\'t find language {model.LanguageId}");
            }
            return new ConferenceLocalization
            {
                Conference = conference,
                Language = language,
                Name = model.Name
            };
        }

        public void AddNewConferenceLocalizationFromModel(ConferenceModel model)
        {
            var conference = GetConferenceById(model.ConferenceId);

            var conferenceLocalization = GetConferenceLocalizationFromModel(conference, model);

            if (_conferenceLocalizationRepository.Set()
                .Any(al => al.ConferenceId == model.ConferenceId && al.LanguageId == model.LanguageId))
            {
                throw new Exception($"localization in language {model.LanguageId} for conference {model.ConferenceId} already exists");
            }

            _conferenceLocalizationRepository.Insert(conferenceLocalization);
        }
        public void UpdateConferenceLocalizationFromModel(ConferenceModel model)
        {
            var conference = GetConferenceById(model.ConferenceId);

            var originalConferenceLocalization = _conferenceLocalizationRepository.Set()
                .FirstOrDefault(al => al.ConferenceId == conference.Id && al.LanguageId == model.LanguageId);

            if (originalConferenceLocalization == null)
            {
                throw new Exception($"no previous localization in language {model.LanguageId} of conference {model.ConferenceId}");
            }

            var newConferenceLocalization = GetConferenceLocalizationFromModel(conference, model);

            originalConferenceLocalization.Name = newConferenceLocalization.Name;

            _conferenceLocalizationRepository.Update(originalConferenceLocalization);
        }
        public void DeleteConferenceLocalizationById(int conferenceId, int languageId)
        {
            var conferenceLocalization = _conferenceLocalizationRepository.Set()
                .FirstOrDefault(al => al.ConferenceId == conferenceId && al.LanguageId == languageId);

            if (conferenceLocalization == null)
            {
                throw new Exception($"localization for conference {conferenceId} in language {languageId} not found");
            }

            _conferenceLocalizationRepository.Delete(conferenceLocalization);
        }
        public IEnumerable<Conference> GetConferences(bool? show, int? categoryId)
        {

            var query = from a in _conferenceRepository.Set()
                        where categoryId == null || a.Category.Id == categoryId 
                        where show == null || a.Show == show
                        select a;

            return query.ToList();
        }
        public ConferenceModel GetConferenceModel(Conference conference, Language language)
        {
            if (conference == null)
            {
                throw new ArgumentNullException(nameof(conference));
            }

            if (language == null)
            {
                throw new ArgumentNullException(nameof(language));
            }

            var conferenceLocalization = conference.ConferenceLocalizations.FirstOrDefault(at => at.Language == language);

            if (conferenceLocalization == null)
            {
                throw new Exception("can\'t find localization for conference");
            }

            return new ConferenceModel
            {
                ConferenceId = conference.Id,
                LanguageId = language.Id,
                Show = conference.Show,
                CategoryId = conference.Category.Id,
                Name = conferenceLocalization.Name
            };
        }
        public ConferenceModel GenerateConferenceModel(Conference conference, int languageId)
        {
            var language = _languageRepository.Set().FirstOrDefault(l => l.Id == languageId);

            if (language == null)
            {
                throw new ArgumentException($"language {languageId} not found", nameof(language));
            }
            return this.GetConferenceModel(conference, language);
        }
    }
}
