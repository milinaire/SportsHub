using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SportsHubDAL.Interfaces;

namespace SportsHubDAL.Entities
{
    public class AdminPermissions : NoIdDBEntity
    {
        [Key]
        public int UserId { get; set; }
        public bool BlockUsers { get; set; }
        public bool DeleteUsers { get; set; }
        public bool CreateOrDeleteAdmins { get; set; }
        public bool CreateOrDeleteArticles { get; set; }
        public bool CreateOrDeleteCategories { get; set; }
        public bool CreateOrDeleteAd { get; set; }
        public bool CreateOrDeleteBanners { get; set; }
        public bool AddOrDeleteLanguage { get; set; }

        public virtual ApplicationUser User { get; set; }
        
    }
}