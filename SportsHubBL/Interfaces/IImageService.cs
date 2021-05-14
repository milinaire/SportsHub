using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Web;
using SportsHubBL.Models;
using SportsHubDAL.Entities;


namespace SportsHubBL.Interfaces
{
    public interface IImageService
    {
        public Image GetImageById(int id);
        
        public Image UpdateImageById(int id, string uri);
        
        public void DeleteTeamById(int id);
        
        public Image GetImage(string uri);
        
        public ImageModel GetModel(Image image);
        
        public Task AddImage(IFormFile imageFile);
        
        public ImageModel AddImageToDb(string uri);
        
        
    }
}