﻿using AutoMapper;
using PreorderPlatform.Entity.Models;
using PreorderPlatform.Entity.Repositories.CategoryRepositories;
using PreorderPlatform.Service.Exceptions;
using PreorderPlatform.Service.Services.CategoryServices;
using PreorderPlatform.Service.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.Services.CategoryServices
{
    internal class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryViewModel>> GetCategoriesAsync()
        {
            try
            {
                var categories = await _categoryRepository.GetAllAsync();
                return _mapper.Map<List<CategoryViewModel>>(categories);
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occurred while fetching categories.", ex);
            }
        }

        public async Task<CategoryViewModel> GetCategoryByIdAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(id);

                if (category == null)
                {
                    throw new NotFoundException($"Category with ID {id} was not found.");
                }

                return _mapper.Map<CategoryViewModel>(category);
            }
            catch (NotFoundException)
            {
                // Rethrow NotFoundException to be handled by the caller
                throw;
            }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while fetching category with ID {id}.", ex);
            }
        }

        public async Task<CategoryViewModel> CreateCategoryAsync(CategoryCreateViewModel model)
        {
            try
            {
                var category = _mapper.Map<Category>(model);
                await _categoryRepository.CreateAsync(category);
                return _mapper.Map<CategoryViewModel>(category);
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occurred while creating the category.", ex);
            }
        }

        public async Task UpdateCategoryAsync(CategoryUpdateViewModel model)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(model.Id);
                category = _mapper.Map(model, category);
                await _categoryRepository.UpdateAsync(category);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while updating category with ID {model.Id}.", ex);
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(id);
                await _categoryRepository.DeleteAsync(category);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while deleting category with ID {id}.", ex);
            }
        }
    }
}