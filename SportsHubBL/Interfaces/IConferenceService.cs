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
    }
}
