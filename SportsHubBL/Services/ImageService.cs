using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SportsHubBL.Interfaces;
using SportsHubDAL.Entities;
using SportsHubDAL.Interfaces;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using SportsHubBL.Models;
using Microsoft.Extensions.Configuration;



namespace SportsHubBL.Services
{
    public class ImageService : IImageService
    {
        
        private const string ContainerName = "imagecontainer";  
        private readonly IRepository<Image> _imageRepository;
        private readonly CloudStorageAccount _cloudStorageAccount = CloudStorageAccount
            .Parse("DefaultEndpointsProtocol=https;AccountName=sporthubblob;AccountKey=Verb4f2R0CWvZ42zFq8hIQNlrs4s8ObTOs1GqAX+apKW+4PLSQsKaFsUoDT4zgROuVCSixtyhAZLVNtdREK2XQ==;EndpointSuffix=core.windows.net");

        /*private readonly CloudStorageAccount _cloudStorageAccount1 = CloudStorageAccount
            .Parse(_config["Images:ConnectionString"]);*/

        public ImageService(IRepository<Image> imageRepository)
        {
            _imageRepository = imageRepository;
        }
        public string GuidGeneration()
        {
            var imageGuid = Guid.NewGuid();
            return imageGuid.ToString();
        }

        public async Task AddImage(IFormFile imageFile, string imageName)
        {
            var cloudBlobClient = _cloudStorageAccount.CreateCloudBlobClient();
            var cloudBlobContainer = cloudBlobClient.GetContainerReference(ContainerName);
            if (await cloudBlobContainer.CreateIfNotExistsAsync())
            {
                await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions
                    {PublicAccess = BlobContainerPublicAccessType.Off});
            }

            var cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(imageName);
            cloudBlockBlob.Properties.ContentType = imageFile.ContentType;

            await cloudBlockBlob.UploadFromStreamAsync(imageFile.OpenReadStream());
            
        }


        private void DeleteBlob(string fileName)   
        {   
            var blobClient = _cloudStorageAccount.CreateCloudBlobClient();  
            var cloudBlobContainer = blobClient.GetContainerReference(ContainerName);
            var fileName1 = fileName.Split(new [] {"container/"}, StringSplitOptions.None)[1];
            var blockBlob = cloudBlobContainer.GetBlockBlobReference(fileName1);  
            //delete blob from container    
            blockBlob.Delete();  
        } 
        
        public ImageModel AddImageToDb(string uri)
        {
            var image = GetImage("https://sporthubblob.blob.core.windows.net/imagecontainer/" + uri);
            
            _imageRepository.Insert(image);
            
            return GetModel(image);
        }

        public void DeleteImageById(int id)
        {
            var image = GetImageById(id);
            if (image == null)
            {
                throw new Exception($"Image with id {id} is not found");
            }
            DeleteBlob(image.Uri);
            _imageRepository.Delete(image);
        }
        
        public ImageModel UpdateImageById(int id, string uri)
        {
            if (uri == null)
            {
                throw new Exception("File was null");
            }
            var image = _imageRepository.Set().FirstOrDefault(a => a.Id == id);
            if (image == null)
            {
                throw new Exception("Image with such id does not exist");
            }
            
            image.Uri = "https://sporthubblob.blob.core.windows.net/imagecontainer/" + uri;
            _imageRepository.Update(image);

            return GetModel(image);
        }

        public Image GetImage(string uri)
        {
            if (uri == null)
                throw new Exception("Uri was null");
            
            return new Image
            {
                Uri = uri
            };
        }
        
        public ImageModel GetModel(Image image)
        {
            if (image == null)
                throw new Exception("image was null");
            
            return new ImageModel
            {
                ImageId = image.Id,
                ImageUri = image.Uri
            };
        }


        public Image GetImageById(int id)
        {
            return _imageRepository.GetById(id);
        }
        
    }
}