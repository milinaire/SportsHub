using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubBL.Models
{
    public class AdvertisingModel { 
    public int AdvertisingId { get; set; }
    public string Url { get; set; }
    public bool IsActive { get; set; }
    public int? ImageId { get; set; }
    public string ImageUri { get; set; }
    public DateTime DateCreated { get; set; }
    public int LanguageId { get; set; }
    public int Opened { get; set; }
    public int Displayed { get; set; }
    public int CategoryId { get; set; }
    public string Headline { get; set; }
    }
}
