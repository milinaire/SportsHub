namespace SportsHubBL.Models
{
    public class PhotoOfTheDayModel
    {
        public int? Id { get; set; }
        
        public string ImageUri { get; set; }
        
        public string Alt { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string Author { get; set; }
        
        public int LanguageId { get; set; }
    }
}