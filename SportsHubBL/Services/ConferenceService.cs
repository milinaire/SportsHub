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

    }
}
