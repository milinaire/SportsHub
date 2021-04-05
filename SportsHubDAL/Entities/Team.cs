﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsHubDAL.Interfaces;

namespace SportsHubDAL.Entities
{
    public class Team : DBEntity
    {
        public int Id { get; set; }
        public Conference Conference { get; set; }
        public Location Location { get; set; }
        public Image Image { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Show { get; set; }
        public IEnumerable<FollowedTeams> FolovedTeams { get; set; }
        public IEnumerable<BreakDown> BreakDowns { get; set; }
        public IEnumerable<TeamLocalization> TeamLocalizations { get; set; }
        public IEnumerable<NewsLetterSubscription> NewsLetterSubscriptions { get; set; }
        public IEnumerable<SportArticle> SportArticle { get; set; }
        
    }
}
