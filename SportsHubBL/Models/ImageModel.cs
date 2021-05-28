using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace SportsHubBL.Models
{
    public class ImageModel
    {
        public int ImageId { get; set; }
        
        public string ImageUri { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IFormFile ImageFile { get; set; }
    }
}