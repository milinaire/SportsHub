using SportsHubBL.Models;
using SportsHubDAL.Entities;

namespace SportsHubBL.Interfaces
{
    public interface IPhotoOfTheDayService
    {
        public PhotoOfTheDayModel GetPhotoOfTheDay();
        
        public PhotoOfTheDayModel UpdatePhotoOfTheDay(PhotoOfTheDayModel model);
        
        public void DeletePhotoOfTheDay();
    }
}