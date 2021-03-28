using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class AdminPermissions
    {
        
        public int UserId { get; set; }
        public bool BlockUsers { get; set; }
        public bool DeleteUsers { get; set; }
        public bool CreateOrDeleteAdmins { get; set; }
        public bool CreateOrDeleteArticles { get; set; }
        public bool CreateOrDeleteCategories { get; set; }
        public bool CreateOrDeleteAd { get; set; }
        public bool CreateOrDeleteBanners { get; set; }
        public bool AddOrDeleteLanguage { get; set; }

        public User User { get; set; }
        
    }
}