using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class SocialNetwork
    {
        
        public bool ShowShare { get; set; }
        public bool ShowFollow { get; set; }
        public bool ShowLoginOrSignUp { get; set; }
        public bool AllowShareVideos { get; set; }
        public bool ShowShareFacebook { get; set; }
        public bool ShowShareGoogle { get; set; }
        public bool ShowShareTwitter { get; set; }
        public bool ShowFollowFacebook { get; set; }
        public bool ShowFollowGoogle { get; set; }
        public bool ShowFollowTwitter { get; set; }
        public bool ShowFollowYoutube { get; set; }
        public bool ShowLoginOrSignUpFacebook { get; set; }
        public bool ShowLoginOrSignUpGoogle { get; set; }
        public bool ShowLoginOrSignUpTwitter { get; set; }
        
        
    }
}