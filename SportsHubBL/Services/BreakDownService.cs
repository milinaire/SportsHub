using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsHubBL.Interfaces;
using SportsHubDAL.Interfaces;
using SportsHubBL.Models;
using SportsHubDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace SportsHubBL.Services
{
    public class BreakDownService : IBreakDownService
    {
        private readonly IRepository<BreakDown> _breakDownRepository;
        private readonly IRepository<Team> _teamRepository;
        private readonly IRepository<Conference> _conferenceRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Language> _languageRepository;

        public BreakDownService(
            IRepository<BreakDown> breakDownRepository,
            IRepository<Team> teamRepository, 
            IRepository<Conference> conferenceRepository, 
            IRepository<Category> categoryRepository, 
            IRepository<Language> languageRepository)
        {
            _breakDownRepository = breakDownRepository;
            _teamRepository = teamRepository;
            _conferenceRepository = conferenceRepository;
            _categoryRepository = categoryRepository;
            _languageRepository = languageRepository;
        }

        public void AddBreakDown(BreakDownModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var breakDown = GetBreakDownFromModel(model);

            _breakDownRepository.Insert(breakDown);
        }

        public void DeleteBreakDown(int id)
        {
            var breakDown = _breakDownRepository.GetById(id);

            if (breakDown == null)
            {
                throw new ArgumentException($"breakDown {id} not found", nameof(breakDown));
            }

            _breakDownRepository.Delete(breakDown);
        }

        public BreakDownModel GenerateBreakDownModel(int breakDownId, int languageId)
        {
            var breakDown = _breakDownRepository.GetById(breakDownId);

            if (breakDown == null)
            {
                throw new ArgumentException($"break down {breakDownId} not found", nameof(breakDownId));
            }

            return GenerateBreakDownModel(breakDown, languageId);
        }

        public BreakDownModel GenerateBreakDownModel(BreakDown breakDown, int languageId)
        {
            if (breakDown == null)
            {
                throw new ArgumentNullException(nameof(breakDown));
            }

            var language = _languageRepository.GetById(languageId);

            if (language == null)
            {
                throw new ArgumentException($"language {languageId} not found");
            }

            var model = new BreakDownModel
            {
                Id = breakDown.Id,
                Show = breakDown.Show,
                Languageid = languageId
            };

            return LocalizeBreakDownModel(model, breakDown, languageId);
        }

        private BreakDownModel LocalizeBreakDownModel(BreakDownModel model, BreakDown breakDown, int languageId)
        {
            if (breakDown.Category == null
                || breakDown.Conference == null
                || breakDown.Team == null)
            {
                breakDown = _breakDownRepository
                    .Set()
                    .Include(bd => bd.Category).ThenInclude(c => c.CategoryLocalizations)
                    .Include(bd => bd.Conference).ThenInclude(c => c.ConferenceLocalizations)
                    .Include(bd => bd.Team).ThenInclude(t => t.TeamLocalizations)
                    .FirstOrDefault(bd => bd.Id == breakDown.Id);
            }

            //TODO: English language default id in call
            model.CategoryId = breakDown.Category.Id;
            model.CategoryName = breakDown.Category
                .CategoryLocalizations.FirstOrDefault(cl => cl.LanguageId == languageId)?.Name ??
                breakDown.Category.CategoryLocalizations.FirstOrDefault(cl => cl.LanguageId == 1/*english*/)?.Name;
            //TODO: English language default id in call
            model.ConferenceId = breakDown.Conference.Id;
            model.ConferenceName = breakDown.Conference
               .ConferenceLocalizations.FirstOrDefault(cl => cl.LanguageId == languageId)?.Name ??
               breakDown.Conference.ConferenceLocalizations.FirstOrDefault(cl => cl.LanguageId == 1/*english*/)?.Name;
            //TODO: English language default id in call
            model.TeamId = breakDown.Team.Id;
            model.TeamName = breakDown.Team
               .TeamLocalizations.FirstOrDefault(cl => cl.LanguageId == languageId)?.Name ??
               breakDown.Team.TeamLocalizations.FirstOrDefault(cl => cl.LanguageId == 1/*english*/)?.Name;

            return model;
        }

        private BreakDown GetBreakDownFromModel(BreakDownModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var category = _categoryRepository.GetById(model.CategoryId);

            if (category == null)
            {
                throw new ArgumentException($"category {model.CategoryId} not found", nameof(model));
            }

            var conference = _conferenceRepository.GetById(model.ConferenceId);

            if (conference == null)
            {
                throw new ArgumentException($"conference {model.ConferenceId} not found", nameof(model));
            }

            var team = _teamRepository.GetById(model.TeamId);

            if (team == null)
            {
                throw new ArgumentException($"team {model.TeamId} not found", nameof(model));
            }

            return new BreakDown
            {
                Id = model.Id,
                Show = model.Show,
                Category = category,
                Conference = conference,
                Team = team
            };
        }

        public IEnumerable<BreakDownModel> GetBreakDowns(int languageId, bool showHidden = false)
        {
            return _breakDownRepository.Set().Where(bd => showHidden || bd.Show == true)
                .Select(bd => GenerateBreakDownModel(bd, languageId));
        }

        public void UpdateBreakDown(int id, BreakDownModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var oldBreakDown = _breakDownRepository.GetById(id);

            if (oldBreakDown == null)
            {
                throw new ArgumentException($"breakDown {id} not found", nameof(id));
            }

            var newBreakDown = GetBreakDownFromModel(model);

            oldBreakDown.Id = newBreakDown.Id;
            oldBreakDown.Show = newBreakDown.Show;
            oldBreakDown.Category = newBreakDown.Category;
            oldBreakDown.Conference = newBreakDown.Conference;
            oldBreakDown.Team = newBreakDown.Team;

            _breakDownRepository.Update(oldBreakDown);
        }
    }
}
