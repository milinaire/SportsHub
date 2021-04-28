using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsHubBL.Models;
using SportsHubDAL.Entities;

namespace SportsHubBL.Interfaces
{
    public interface IConferenceService
    {
        public void AddConferenceFromModel(ConferenceModel model);
        public Conference GetConferenceById(int id);
        public void DeleteConferenceById(int id);
        public void UpdateConferenceById(int id, ConferenceModel model);
        public void AddNewConferenceLocalizationFromModel(ConferenceModel model);
        public void UpdateConferenceLocalizationFromModel(ConferenceModel model);
        public void DeleteConferenceLocalizationById(int conferenceId, int languageId);
        public ConferenceModel GetConferenceModel(Conference conference, Language language);
        public ConferenceModel GenerateConferenceModel(Conference conference, int languageId);
        public IEnumerable<Conference> GetConferences(bool? show, int? categoryId);
    }
}
