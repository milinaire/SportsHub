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

        public void DeleteImageById(int id);
        
        public Image GetImage(string uri);
        
        public ImageModel GetModel(Image image);
        
        public ImageModel UpdateImageById(int id, string uri);
        
        public Task AddImage(IFormFile imageFile, string imageName);
        
        public ImageModel AddImageToDb(string uri);
        
        
    }
}