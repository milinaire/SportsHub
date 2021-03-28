using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsOnline { get; set; }
        public bool IsActive { get; set; }
        public Image Image { get; set; }
        public int LanguageId { get; set; }
        public DateTime RegisteredDate { get; set; }

        public Language Language { get; set; }
        public IEnumerable<Votes> Votes { get; set; }
        public IEnumerable<FollowedTeams> FollowedTeams { get; set; }
        public IEnumerable<Comment> Comment { get; set; }
        public IEnumerable<Like> Like { get; set; }
        public IEnumerable<Views> Views { get; set; }
        public IEnumerable<AdminPermissions> AdminPermissions { get; set; }
      
    }
}