using SportsHubBL.Models;
using SportsHubDAL.Entities;
using System.Collections.Generic;
namespace SportsHubBL.Interfaces
{
    public interface ITeamService
    {
        public IEnumerable<Team> GetTeams(int? conferenceId, int? categoryId, int? teamId, int? locationId);

        public TeamLocalization GetTeamLocalization(int teamId, int languageId);
        
        public void AddTeamFromModel(TeamModel team);
        
        public void AddNewTeamLocalizationFromModel(TeamModel model);
         
        public TeamModel GetTeamModel(Team team, Language language);

        public TeamModel GenerateTeamModel(Team team, int languageId);

        public void DeleteTeamById(int id);
        
        public void DeleteTeamLocalizationById(int teamId, int languageId);
        public void UpdateTeamFromModel(int teamId, TeamModel model);
        public void UpdateTeamLocalizationFromModel(TeamModel model);

    }
}