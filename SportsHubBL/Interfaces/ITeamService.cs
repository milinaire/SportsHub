using SportsHubBL.Models;
using SportsHubDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubBL.Interfaces
{
    public interface ITeamService
    {
        public IEnumerable<Team> GetAllTeams();
        
        public IEnumerable<Team> GetTeamsByConference(int conferenceId);
        
        public IEnumerable<Team> GetTeamsByCategory(int categoryId);
        
        public IEnumerable<Team> GetTeamsByLocation(int locationId);
        
        public TeamLocalization GetTeamLocalization(int teamId, int languageId);
        
        public Team GetTeamById(int id);
        
        public void AddTeamFromModel(TeamModel team);
         
        public TeamModel GetTeamModel(Team team, Conference conference);

        public TeamModel GenerateTeamModel(Team team, int conferenceId);

        public void DeleteTeamById(int id);
        
        public void DeleteTeamConferenceById(int teamId, int conferenceId); 
        
        
        public void UpdateTeamConferenceFromModel(TeamModel model);
        
    }
}