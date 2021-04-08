﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsHubDAL.Entities
{
    public class ContributorsSectionsLocalization
    {
        public string Headline { get; set; }
        [Column(TypeName = "text")]
        public string Text { get; set; }
        public int SectionId { get; set; }
        public int LanguageId { get; set; }
        public ContributorsSection ContributorsSection { get; set; }
        public Language Language { get; set; }
    }
}
