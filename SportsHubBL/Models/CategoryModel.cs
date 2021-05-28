namespace SportsHubBL.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        
        public int? ConferenceId { get; set; }
        
        public bool? Show { get; set; }
        
        public bool? IsEditable { get; set; }
        
        public int? LanguageId { get; set; }
        
        public string Name { get; set; }
        
        public int? NewsLetterSubId { get; set; }
        
    }
}