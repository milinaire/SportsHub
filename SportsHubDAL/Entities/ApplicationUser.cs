using Microsoft.AspNetCore.Identity;

namespace SportsHubDAL.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public int PreferredLanguage { get; set; }
    }
}
