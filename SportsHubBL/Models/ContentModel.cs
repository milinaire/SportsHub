using SportsHubBL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubBL.Models
{
    public class ContentModel
    {
        public int Id { get; set; }
        public int ContentItemId { get; set; }
        public ContentItemType Type { get; set; }
        public bool IsPublished { get; set; }
        public DateTime Datetime { get; set; }
        public bool ShowComments { get; set; }
    }
}
