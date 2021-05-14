using System.Collections.Generic;
using SportsHubBL.Models;
using SportsHubDAL.Entities;

namespace SportsHubBL.Interfaces
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryModel> GetCategories(int languageId);

        public Category GetCategoryById(int id);

        public CategoryLocalization GetCategoryLocalization(int categoryId, int languageId);

        public IEnumerable<CategoryLocalization> GetAllCategoryLocalizations(int categoryId);

        public Category AddCategoryFromModel(CategoryModel model);
        
        public CategoryLocalization AddNewCategoryLocalizationFromModel(CategoryModel model);
         
        public CategoryModel GetCategoryModel(Category category, Language language);

        public CategoryModel GenerateCategoryModel(Category category, int languageId);

        public void DeleteCategoryById(int id);
        
        public void DeleteCategoryLocalizationById(int categoryId, int languageId);
        public Category UpdateCategoryFromModel(int categoryId, CategoryModel model);
        public CategoryLocalization UpdateCategoryLocalizationFromModel(CategoryModel model);
    }
}