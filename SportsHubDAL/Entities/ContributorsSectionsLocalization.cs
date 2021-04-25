﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using SportsHubDAL.Interfaces;

namespace SportsHubDAL.Entities
{
    public class ContributorsSectionsLocalization : NoIdDBEntity
    {
        public string Headline { get; set; }
        [Column(TypeName = "text")]
        public string Text { get; set; }
        public int SectionId { get; set; }
        public int LanguageId { get; set; }
        public virtual ContributorsSection ContributorsSection { get; set; }
        public virtual Language Language { get; set; }
    }
}
