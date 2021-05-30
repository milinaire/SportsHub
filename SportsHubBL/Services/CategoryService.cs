using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SportsHubBL.Interfaces;
using SportsHubBL.Models;
using SportsHubDAL.Entities;
using SportsHubDAL.Interfaces;

namespace SportsHubBL.Services
{
    public class CategoryService : ICategoryService
    {
        
        private readonly INoIdRepository<Category> _categoryRepository;
        private readonly INoIdRepository<CategoryLocalization> _categoryLocalizationRepository;
        private readonly ILanguageService _languageService;
        public CategoryService(
            INoIdRepository<Category> categoryRepository,
            INoIdRepository<CategoryLocalization> categoryLocalizationRepository,
            ILanguageService languageService)
        {
            _categoryRepository = categoryRepository;
            _categoryLocalizationRepository = categoryLocalizationRepository;
            _languageService = languageService;
        }

        public IEnumerable<CategoryModel> GetCategories(int languageId)
        {
            var language = _languageService.GetLanguage(languageId);
            var query = (from a in _categoryRepository.Set()
                select a).ToList();
            var models = query.Select(ca => GetCategoryModel(ca ,language));
            return models;
        }

        public Category AddCategoryFromModel(CategoryModel model)
        {
            var category = GetCategoryFromModel(model);

            if (_categoryRepository.Set().Any(a => a.Id == category.Id))
            {
                throw new ArgumentException($"Category with id {category.Id} is already taken", nameof(model));
            }

            _categoryRepository.Insert(category);

            return category;
        }
        
        private Category GetCategoryFromModel(CategoryModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }


            return new Category
            {
                IsEditable = model.IsEditable ?? default,
                Show = model.Show ?? default
            };
            
        }
        
        public CategoryLocalization AddNewCategoryLocalizationFromModel(CategoryModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var category = _categoryRepository.Set().FirstOrDefault(c => c.Id == model.Id);

            if (category == null)
            {
                throw new Exception($"category {model.Id} not found");
            }

            var categoryLocalization = GetCategoryLocalizationFromModel(category, model);

            _categoryLocalizationRepository.Insert(categoryLocalization);

            return categoryLocalization;
        }

        public CategoryModel GetCategoryModel(Category category, Language language)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            if (language == null)
            {
                throw new ArgumentNullException(nameof(language));
            }

            if (category.CategoryLocalizations == null)
            {
                category = _categoryRepository.Set()
                    .Include(a => a.CategoryLocalizations)
                    .FirstOrDefault(a => a == category);

                if (category == null)
                {
                    throw new ArgumentNullException(nameof(category));
                }
            }
            
            var categoryLocalization = category.CategoryLocalizations
                .FirstOrDefault(at => at.Language == language)??
                category.CategoryLocalizations.FirstOrDefault(cl => cl.LanguageId == _languageService.DefaultSiteLanguageId);

            
            return new CategoryModel
            {
                Id = category.Id,
                Show = category.Show,
                LanguageId = categoryLocalization?.LanguageId ?? default,
                Name = categoryLocalization?.Name
            };
        }

        public CategoryModel GenerateCategoryModel(Category category, int languageId)
        {
            var language = _languageService.GetLanguage(languageId);

            if (language == null)
            {
                throw new Exception("language was null");
            }

            var categoryModel = GetCategoryModel(category, language);
            return LocalizeCategoryModel(categoryModel,category,languageId);
        }

        private CategoryModel LocalizeCategoryModel(CategoryModel model, Category category, int languageId)
        {
            if (category == null)
            {
                category = _categoryRepository.Set()
                    .Include(a => a.CategoryLocalizations)
                    .FirstOrDefault(a => a == category);
            }

            if (category != null)
            {
                model.LanguageId = languageId;
                model.Name = category.CategoryLocalizations
                                 .FirstOrDefault(tl => tl.LanguageId == languageId)?.Name ??
                             category.CategoryLocalizations.FirstOrDefault(tl => tl.LanguageId == 1 /*english*/)?.Name;
                return model;
            }

            throw new Exception($"Model was null");
        }

        public void DeleteCategoryById(int id)
        {
            var category =_categoryRepository.Set().FirstOrDefault(a => a.Id == id);

            if (category == null)
            {
                throw new Exception($"Category {id} not found");
            }

            _categoryRepository.Delete(category);
        }

        public void DeleteCategoryLocalizationById(int categoryId, int languageId)
        {
            var category = _categoryRepository.Set().Include(c => c.CategoryLocalizations).FirstOrDefault(c => c.Id == categoryId);
            if (category == null)
            {
                throw new Exception($"category {categoryId} not found");
            }

            var localization = category.CategoryLocalizations.FirstOrDefault(cl => cl.LanguageId == languageId);

            if (localization == null)
            {
                throw new Exception($"localization for category {categoryId} in language {languageId} not found");
            }

            _categoryLocalizationRepository.Delete(localization);
        }

        public Category UpdateCategoryFromModel(int categoryId, CategoryModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var category = _categoryRepository.Set().FirstOrDefault(c => c.Id == model.Id);

            if (category == null)
            {
                throw new Exception($"category {categoryId} not found");
            }

            var updatedCategory = GetCategoryFromModel(model);

            category.IsEditable = updatedCategory.IsEditable;
            category.Show = updatedCategory.Show;

            _categoryRepository.Update(category);

            return category;
        }

        private CategoryLocalization GetCategoryLocalizationFromModel(Category category, CategoryModel model)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var language = _languageService.GetLanguage((int)model.LanguageId);

            if (language == null)
            {
                throw new Exception($"can\'t find language {model.LanguageId}");
            }

            return new CategoryLocalization
            {
                Category = category,
                CategoryId = category.Id,
                Language = language,
                LanguageId = language.Id,
                Name = model.Name
            };
        }

        public CategoryLocalization UpdateCategoryLocalizationFromModel(CategoryModel model)
        {
            var category = _categoryRepository.Set().Include(c => c.CategoryLocalizations).FirstOrDefault(c => c.Id == model.Id);

            if (category == null)
            {
                throw new Exception($"category {model.Id} not found");
            }

            var categoryLocalization = category.CategoryLocalizations.FirstOrDefault(cl => cl.LanguageId == model.LanguageId);

            if (categoryLocalization == null)
            {
                throw new Exception($"no previous localization in language {model.LanguageId} of category {model.Id}");
            }

            var newLocalization = GetCategoryLocalizationFromModel(category, model);

            categoryLocalization.Name = newLocalization.Name;

            _categoryLocalizationRepository.Update(categoryLocalization);

            return categoryLocalization;
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.Set().FirstOrDefault(c => c.Id == id);
        }

        public CategoryLocalization GetCategoryLocalization(int categoryId, int languageId)
        {
            var category = _categoryRepository.Set()
                .Include(c => c.CategoryLocalizations)
                .FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
            {
                throw new Exception($"category {categoryId} not found");
            }

            return category.CategoryLocalizations.FirstOrDefault(c => c.LanguageId == languageId);
        }

        public IEnumerable<CategoryLocalization> GetAllCategoryLocalizations(int categoryId)
        {
            return _categoryLocalizationRepository.Set().Where(cl => cl.CategoryId == categoryId);
        }
    }
}