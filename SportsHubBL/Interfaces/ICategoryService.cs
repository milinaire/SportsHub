using System.Collections.Generic;
using SportsHubBL.Models;
using SportsHubDAL.Entities;

namespace SportsHubBL.Interfaces
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryModel> GetCategories(int languageId);
        
        public void AddCategoryFromModel(CategoryModel model);
        
        public void AddNewCategoryLocalizationFromModel(CategoryModel model);
         
        public CategoryModel GetCategoryModel(Category category, Language language);

        public CategoryModel GenerateCategoryModel(Category category, int languageId);

        public void DeleteCategoryById(int id);
        
        public void DeleteCategoryLocalizationById(int categoryId, int languageId);
        public void UpdateCategoryFromModel(int categoryId, CategoryModel model);
        public void UpdateCategoryLocalizationFromModel(CategoryModel model);
    }
}