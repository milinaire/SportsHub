using SportsHubBL.Interfaces;
using SportsHubBL.Models;
using SportsHubDAL.Entities;
using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SportsHubBL.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepository<Team> _teamRepository;
        private readonly IRepository<Language> _languageRepository;
        private readonly IRepository<Conference> _conferenceRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Location> _locationRepository;
        private readonly IRepository<Image> _imageRepository;
        private readonly IRepository<TeamLocalization> _teamLocalizationRepository;


        public TeamService(
            IRepository<Team> teamRepository,
            IRepository<Language> languageRepository,
            IRepository<Conference> conferenceRepository,
            IRepository<Category> categoryRepository,
            IRepository<Location> locationRepository,
            IRepository<Image> imageRepository,
            IRepository<TeamLocalization> teamLocalizationRepository
            )
        {
            _teamRepository = teamRepository;
            _languageRepository = languageRepository;
            _conferenceRepository = conferenceRepository;
            _categoryRepository = categoryRepository;
            _locationRepository = locationRepository;
            _imageRepository = imageRepository;
            _teamLocalizationRepository = teamLocalizationRepository;
        }

        public IEnumerable<Team> GetAllTeams()
        {
            try
            {
                return _teamRepository.Set().Where(a => a != null);
            }
            catch
            {
                throw new ArgumentException("teams were null", nameof(_teamRepository));
            }
            
        }

        public IEnumerable<Team> GetTeamsByConference(int conferenceId)
        {
            var conference = _conferenceRepository.Set().FirstOrDefault(c => c.Id == conferenceId);

            if (conference == null)
            {
                throw new ArgumentException("conference was null", nameof(conferenceId));
            }
            
            return _teamRepository.Set().Where(a => a.Conference == conference);
        }

        public IEnumerable<Team> GetTeamsByCategory(int categoryId)
        {
            var category = _categoryRepository.Set().FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
            {
                throw new ArgumentException("category was null", nameof(categoryId));
            }
            
            return _teamRepository.Set().Where(a => a.Conference.Category == category);
        }

        public IEnumerable<Team> GetTeamsByLocation(int locationId)
        {
            var location = _locationRepository.Set().FirstOrDefault(c => c.Id == locationId);

            if (location == null)
            {
                throw new ArgumentException("category was null", nameof(locationId));
            }
             
            return _teamRepository.Set().Where(a => a.Location == location);
        }

        public TeamLocalization GetTeamLocalization(int teamId, int languageId)
        {
            var team = _teamRepository.Set().FirstOrDefault(a => a.Id == teamId);

            if (team == null)
            {
                throw new ArgumentException("team was null", nameof(teamId));
            }

            var language = _languageRepository.Set().FirstOrDefault(l => l.Id == languageId);

            if (language == null)
            {
                throw new ArgumentException("language was null", nameof(languageId));
            }

            return _teamLocalizationRepository.Set().FirstOrDefault(al => al.Team == team && al.Language == language);
        }

        public Team GetTeamById(int id)
        {
            var team = _teamRepository.Set().FirstOrDefault(a => a.Id == id);
            if (team != null)
                return team;
            throw new ArgumentException("Team not found", nameof(_teamRepository));

        }

        public void AddTeamFromModel(TeamModel model)
        {
            var team = GetTeamFromModel(model);
            _teamRepository.Insert(team);
        }
        
        private TeamLocalization GetTeamLocalizationFromModel(Team team, TeamModel model)
        {
            var language = _languageRepository.Set().FirstOrDefault(l => l.Id == model.LanguageId);

            if (language == null)
            {
                throw new ArgumentException($"can\'t find language {model.LanguageId}", nameof(model));
            }

            return new TeamLocalization
            {
                Team = team,
                Language = language,
                Name = model.Name,
                Description = model.Description
            };
        }

        
        public void AddNewTeamLocalizationFromModel(TeamModel model)
        {
            var team = GetTeamFromModel(model);
            

            var teamLocalization = GetTeamLocalizationFromModel(team, model);

            if (_teamLocalizationRepository.Set()
                .Any(al => al.TeamId == model.TeamId && al.LanguageId == model.LanguageId))
            {
                throw new ArgumentException($"localization in language {model.LanguageId} for team {model.TeamId} already exists", nameof(model));
            }

            _teamLocalizationRepository.Insert(teamLocalization);
        }

        public TeamModel GetTeamModel(Team team, Language language)
        {
            if (team == null)
            {
                throw new ArgumentNullException(nameof(team));
            }

            if (language == null)
            {
                throw new ArgumentNullException(nameof(language));
            }

            if (team.Conference == null || team.Location == null || team.Image == null)
            {
                team = _teamRepository.Set()
                    .Include(a => a.Conference)
                    .Include(a => a.Location)
                    .Include(a => a.Image)
                    .Include(a => a.TeamLocalizations)
                    .FirstOrDefault(a => a == team);

                if (team == null)
                {
                    throw new ArgumentNullException(nameof(team));
                }
            }
            
            var teamLocalization = team.TeamLocalizations.FirstOrDefault(at => at.Language == language);

            
            return new TeamModel
            {
                ImageId = team.Image.Id,
                ImageUri = team.Image.Uri,
                LocationId = team.Location.Id,
                LocationUri = team.Location.Uri,
                ConferenceId = team.Conference.Id,
                CategoryId = team.Conference.Category.Id,
                DateCreated= team.DateCreated,
                Show = team.Show,
                LanguageId = teamLocalization.LanguageId != null ?  teamLocalization.LanguageId : default,
                Name = teamLocalization.Name,
                Description = teamLocalization.Description
            };
        }
        
        private Team GetTeamFromModel(TeamModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_teamRepository.Set().Any(a => a.Id == model.TeamId))
            {
                throw new ArgumentException($"team id {model.TeamId} is already taken", nameof(model));
            }

            var conference = _conferenceRepository.Set().FirstOrDefault(c => c.Id == model.ConferenceId);
            
            var category = _categoryRepository.Set().FirstOrDefault(c => c.Id == model.CategoryId);

            
            if (conference == null && category != null)
            {
                conference = new Conference
                {
                    Category = category
                };
            }
            
            var image = _imageRepository.Set().FirstOrDefault(i => i.Id == model.ImageId);

            if (image == null && model.ImageUri != default)
            {
                image = new Image
                {
                    Uri = model.ImageUri
                };
            }
            var location = _locationRepository.Set().FirstOrDefault(c => c.Id == model.LocationId);
            if (location == null && model.LocationUri != default)
            {
                location = new Location
                {
                    Uri = model.LocationUri
                };
            }

            
            return new Team
            {
                Image = image,
                Conference = conference,
                Location = location,
                DateCreated = (DateTime)model.DateCreated != null ? (DateTime)model.DateCreated : default,
                Show = (bool) model.Show ? (bool) model.Show : default,
                
            };
            
        }
        
        public TeamModel GenerateTeamModel(Team team, int languageId)
        {
            var language = _languageRepository.Set().FirstOrDefault(l => l.Id == languageId);

            if (language == null)
            {
                throw new ArgumentException("language was null", nameof(language));
            }

            return GetTeamModel(team, language);
        }

        public void DeleteTeamById(int id)
        {
            var team =_teamRepository.Set().FirstOrDefault(a => a.Id == id);

            if (team == null)
            {
                throw new ArgumentException($"Team {id} not found", nameof(id));
            }

            _teamRepository.Delete(team);
        }

        public void DeleteTeamLocalizationById(int teamId, int languageId)
        {
            var teamLocalization = _teamLocalizationRepository.Set()
                .FirstOrDefault(al => al.TeamId == teamId && al.LanguageId == languageId);

            if (teamLocalization == null)
            {
                throw new ArgumentException($"localization for team {teamId} in language {languageId} not found");
            }

            _teamLocalizationRepository.Delete(teamLocalization);
        }

        public void DeleteTeamConferenceById(int teamId, int conferenceId)
        {
            var team =_teamRepository.Set().FirstOrDefault(a => a.Id == teamId);
            if (team == null)
            {
                throw new ArgumentException($"Conference of Team {teamId} not found", nameof(conferenceId));
            }
            
            _conferenceRepository.Delete(team.Conference);
        }

        public void UpdateTeamLocalizationFromModel(TeamModel model)
        {
            var team = GetTeamFromModel(model);

            var originalTeamLocalization = _teamLocalizationRepository.Set()
                .FirstOrDefault(al => al.TeamId == team.Id && al.LanguageId == model.LanguageId);

            if (originalTeamLocalization == null)
            {
                throw new ArgumentException($"no previous localization in language {model.LanguageId} of team {model.TeamId}", nameof(model));
            }

            var newTeamLocalization = GetTeamLocalizationFromModel(team, model);

            originalTeamLocalization.LanguageId = newTeamLocalization.LanguageId;
            originalTeamLocalization.Name = newTeamLocalization.Name;
            originalTeamLocalization.Description = newTeamLocalization.Description;

            _teamLocalizationRepository.Update(originalTeamLocalization);
        }

        public void UpdateTeamConferenceFromModel(TeamModel model)
        {
            var team = GetTeamFromModel(model);

            var originalTeamConference = _conferenceRepository.Set()
                .FirstOrDefault(conf => conf.Id == team.Conference.Id);

            if (originalTeamConference == null)
            {
                throw new ArgumentException($"no previous conference  {model.ConferenceId} in team {model.TeamId}", nameof(model));
            }
            _conferenceRepository.Update(originalTeamConference);
        }
    }
}