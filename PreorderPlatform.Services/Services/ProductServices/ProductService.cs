﻿using AutoMapper;
using PreorderPlatform.Entity.Entities;
using PreorderPlatform.Entity.Repositories.ProductRepositories;
using PreorderPlatform.Service.ViewModels.Product;
using PreorderPlatform.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.Services.ProductServices
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductViewModel>> GetProductsAsync()
        {
            try
            {
                var products = await _productRepository.GetAllAsync();
                return _mapper.Map<List<ProductViewModel>>(products);
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occurred while fetching products.", ex);
            }
        }

        public async Task<ProductViewModel> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);

                if (product == null)
                {
                    throw new NotFoundException($"Product with ID {id} was not found.");
                }

                return _mapper.Map<ProductViewModel>(product);
            }
            catch (NotFoundException)
            {
                // Rethrow NotFoundException to be handled by the caller
                throw;
            }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while fetching product with ID {id}.", ex);
            }
        }

        public async Task<ProductViewModel> CreateProductAsync(ProductCreateViewModel model)
        {
            try
            {
                var product = _mapper.Map<Product>(model);
                await _productRepository.CreateAsync(product);
                return _mapper.Map<ProductViewModel>(product);
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occurred while creating the product.", ex);
            }
        }

        public async Task UpdateProductAsync(ProductUpdateViewModel model)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(model.Id);
                product = _mapper.Map(model, product);
                await _productRepository.UpdateAsync(product);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while updating product with ID {model.Id}.", ex);
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                await _productRepository.DeleteAsync(product);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while deleting product with ID {id}.", ex);
            }
        }
    }
}