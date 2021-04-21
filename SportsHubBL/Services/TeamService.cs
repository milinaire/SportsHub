using SportsHubBL.Interfaces;
using SportsHubBL.Models;
using SportsHubDAL.Entities;
using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SportsHubBL.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepository<Team> _teamRepository;
        private readonly IRepository<Language> _languageRepository;
        private readonly IRepository<Conference> _conferenceRepository;
        private readonly INoIdRepository<Category> _categoryRepository;
        private readonly IRepository<Location> _locationRepository;
        private readonly IRepository<Image> _imageRepository;
        private readonly INoIdRepository<TeamLocalization> _teamLocalizationRepository;


        public TeamService(
            IRepository<Team> teamRepository,
            IRepository<Language> languageRepository,
            IRepository<Conference> conferenceRepository,
            INoIdRepository<Category> categoryRepository,
            IRepository<Location> locationRepository,
            IRepository<Image> imageRepository,
            INoIdRepository<TeamLocalization> teamLocalizationRepository
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
        
        public IEnumerable<Team> GetTeams(int? conferenceId, int? categoryId, int? teamId, int? locationId)
        {
            
            var query = from a in _teamRepository.Set()
                    .Include(sa => sa.Conference).ThenInclude(saa => saa.Category)
                    .Include(sa => sa.Location)
                    .Include(sa => sa.Image)
                where categoryId == null || a.Conference != null && a.Conference.Category.Id == categoryId
                where conferenceId == null || a.Conference.Id == conferenceId
                where teamId == null || a.Id == teamId
                where locationId == null || a.Location.Id == locationId
                select a;

            return query.ToList();
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
                TeamId = team.Id,
                ImageId = team.Image.Id,
                ImageUri = team.Image.Uri,
                LocationId = team.Location.Id,
                LocationUri = team.Location.Uri,
                ConferenceId = team.Conference.Id,
                CategoryId = team.Conference.Category.Id,
                DateCreated= team.DateCreated,
                Show = team.Show,
                LanguageId = teamLocalization?.LanguageId ?? default,
                Name = teamLocalization?.Name,
                Description = teamLocalization?.Description
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
                DateCreated = model.DateCreated ?? default,
                Show = model.Show ?? default,
                
            };
            
        }
                
        private TeamModel LocalizeTeamModel(TeamModel model, Team team, int languageId)
        {
            if (team?.Conference == null)
            {
                team = _teamRepository.Set()
                    .Include(sa => sa.Conference).ThenInclude(sa=>sa.Category)
                    .Include(sa => sa.TeamLocalizations)
                    .Include(t => t.Conference).ThenInclude(c => c.ConferenceLocalizations)
                    .Include(t => t.Location).ThenInclude(t=>t.Id)
                    .FirstOrDefault(sa => sa == team);
            }

            if (team != null)
            {
                model.LocationId = team.Location.Id;
                model.LocationUri = team.Location.Uri;
                if (team.Conference != null) model.ConferenceId = team.Conference.Id;
                //TODO: English language default id in call
                model.TeamId = team.Id;
                model.Name = team.TeamLocalizations
                                 .FirstOrDefault(tl => tl.LanguageId == languageId)?.Name ??
                             team.TeamLocalizations.FirstOrDefault(tl => tl.LanguageId == 1 /*english*/)?.Name;
                //TODO: English language default id in call
                model.Description = team.TeamLocalizations
                                        .FirstOrDefault(cl => cl.LanguageId == languageId)?.Description ??
                                    team.TeamLocalizations.FirstOrDefault(cl => cl.LanguageId == 1 /*english*/)?.Description;
                return model;
            }

            throw new ArgumentException($"Model was null");

        }
        
        public TeamModel GenerateTeamModel(Team team, int languageId)
        {
            var language = _languageRepository.Set().FirstOrDefault(l => l.Id == languageId);

            if (language == null)
            {
                throw new ArgumentException("language was null", nameof(language));
            }

            var teamModel = GetTeamModel(team, language);
            return LocalizeTeamModel(teamModel,team,languageId);
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

        public void UpdateTeamFromModel(int teamId, TeamModel model)
        {
            //TODO Add language and id changing
            var team = _teamRepository.Set()
                .FirstOrDefault(sa => sa.Id == teamId);
            
            var teamLocalization = _teamLocalizationRepository.Set()
                .FirstOrDefault(sa => sa.LanguageId == team.Location.Id);
            
            /*var teamConference = _conferenceRepository.Set()
                .FirstOrDefault(sa => sa.Id == team.Conference.Id);
            
            var teamCategory = _categoryRepository.Set()
                .FirstOrDefault(sa => sa.Id == team.Conference.Category.Id);*/
            var teamImage = _imageRepository.Set()
                .FirstOrDefault(sa => sa.Id == team.Image.Id);

            var teamLocation = _locationRepository.Set()
                .FirstOrDefault(sa => sa.Id == team.Location.Id);

            
            if (team == null)
            {
                throw new ArgumentException($"team {teamId} not found", nameof(teamId));
            }

            var newTeam = GetTeamFromModel(model);
            if (model.LanguageId == null)
            {
                throw new ArgumentNullException($"You cant edit field Description and Name without parameter LanguageId",
                    nameof(model.LanguageId));
            }
            var newTeamLocalization = GetTeamLocalizationFromModel(team, model);
            team.Show = model.Show != null ? newTeam.Show : team.Show;
            team.DateCreated = model.DateCreated != null ? newTeam.DateCreated : team.DateCreated;
            if (teamLocalization != null)
            {
                /*teamLocalization.LanguageId = model.LanguageId != null
                    ? newTeamLocalization.LanguageId
                    : teamLocalization.LanguageId;*/
                teamLocalization.Name = model.Name != null ? newTeamLocalization.Name : teamLocalization.Name;
                teamLocalization.Description = model.Description != null 
                    ? newTeamLocalization.Description
                    : teamLocalization.Description;
            }
            if (teamImage != null)
            {
                //teamImage.Id = model.ImageId != null ? newTeam.Image.Id : teamImage.Id ;
                teamImage.Uri = model.ImageUri != null ? newTeam.Image.Uri : teamImage.Uri;
            }
            if (teamLocation != null)
            {
                //teamLocation.Id = model.LocationId != null ? newTeam.Location.Id : teamLocation.Id ;
                teamLocation.Uri = model.LocationUri != null ? newTeam.Location.Uri : teamLocation.Uri;
            }
            //TODO Check code below and upper, I don't know how to change id, so...
            /*if (teamConference != null)
            {
                teamConference.Id = model.ConferenceId != null ? newTeam.Conference.Id : teamConference.Id ;
            }
            if (teamCategory != null)
            {
                teamCategory.Id = model.CategoryId != null ? newTeam.Conference.Id : teamCategory.Id ;
            }
            _categoryRepository.Update(teamCategory);
            _conferenceRepository.Update(teamConference);
           
            _locationRepository.Update(teamLocation);*/
            _teamRepository.Update(team);
            _imageRepository.Update(teamImage);
            _locationRepository.Update(teamLocation);
            _teamLocalizationRepository.Update(teamLocalization);
        }
    }
}