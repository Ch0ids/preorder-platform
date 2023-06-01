using AutoMapper;
using PreorderPlatform.Entity.Entities;
using PreorderPlatform.Entity.Repositories.BusinessRepositories;
using PreorderPlatform.Service.ViewModels.Business;
using PreorderPlatform.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.Services.BusinessServices
{
    public class BusinessService : IBusinessService
    {
        private readonly IBusinessRepository _businessRepository;
        private readonly IMapper _mapper;

        public BusinessService(IBusinessRepository businessRepository, IMapper mapper)
        {
            _businessRepository = businessRepository;
            _mapper = mapper;
        }

        public async Task<List<BusinessViewModel>> GetBusinessesAsync()
        {
            try
            {
                var businesses = await _businessRepository.GetAllAsync();
                return _mapper.Map<List<BusinessViewModel>>(businesses);
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occurred while fetching businesses.", ex);
            }
        }

        public async Task<BusinessViewModel> GetBusinessByIdAsync(int id)
        {
            try
            {
                var business = await _businessRepository.GetByIdAsync(id);

                if (business == null)
                {
                    throw new NotFoundException($"Business with ID {id} was not found.");
                }

                return _mapper.Map<BusinessViewModel>(business);
            }
            catch (NotFoundException)
            {
                // Rethrow NotFoundException to be handled by the caller
                throw;
            }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while fetching business with ID {id}.", ex);
            }
        }

        public async Task<BusinessViewModel> CreateBusinessAsync(BusinessCreateViewModel model)
        {
            try
            {
                var business = _mapper.Map<Business>(model);
                await _businessRepository.CreateAsync(business);
                return _mapper.Map<BusinessViewModel>(business);
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occurred while creating the business.", ex);
            }
        }

        public async Task UpdateBusinessAsync(BusinessUpdateViewModel model)
        {
            try
            {
                var business = await _businessRepository.GetByIdAsync(model.Id);
                business = _mapper.Map(model, business);
                await _businessRepository.UpdateAsync(business);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while updating business with ID {model.Id}.", ex);
            }
        }

        public async Task DeleteBusinessAsync(int id)
        {
            try
            {
                var business = await _businessRepository.GetByIdAsync(id);
                await _businessRepository.DeleteAsync(business);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while deleting business with ID {id}.", ex);
            }
        }
    }
}