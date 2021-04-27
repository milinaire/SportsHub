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
        private readonly IRepository<Language> _languageRepository;
        public CategoryService(
            INoIdRepository<Category> categoryRepository,
            INoIdRepository<CategoryLocalization> categoryLocalizationRepository,
            IRepository<Language> languageRepository)
        {
            _categoryRepository = categoryRepository;
            _categoryLocalizationRepository = categoryLocalizationRepository;
            _languageRepository = languageRepository;
        }

        public IEnumerable<CategoryModel> GetCategories(int languageId)
        {
            var language = _languageRepository.GetById(languageId);
            var query = (from a in _categoryRepository.Set()
                select a).ToList();
            var models = query.Select(ca => GetCategoryModel(ca ,language));
            return models;
        }

        public void AddCategoryFromModel(CategoryModel model)
        {
            var category = GetCategoryFromModel(model);
            _categoryRepository.Insert(category);
        }
        
        private Category GetCategoryFromModel(CategoryModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_categoryRepository.Set().Any(a => a.Id == model.Id))
            {
                throw new ArgumentException($"Category with id {model.Id} is already taken", nameof(model));
            }
            return new Category
            {
                IsEditable = model.IsEditable ?? default,
                Show = model.Show ?? default
            };
            
        }
        
        public void AddNewCategoryLocalizationFromModel(CategoryModel model)
        {
            throw new NotImplementedException();
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
            
            var categoryLocalization = category.CategoryLocalizations.FirstOrDefault(at => at.Language == language);

            
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
            var language = _languageRepository.Set().FirstOrDefault(l => l.Id == languageId);

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
            throw new NotImplementedException();
        }

        public void UpdateCategoryFromModel(int categoryId, CategoryModel model)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategoryLocalizationFromModel(CategoryModel model)
        {
            throw new NotImplementedException();
        }
    }
}