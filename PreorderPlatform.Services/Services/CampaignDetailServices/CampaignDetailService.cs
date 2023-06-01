using AutoMapper;
using PreorderPlatform.Entity.Entities;
using PreorderPlatform.Entity.Repositories.CampaignDetailRepositories;
using PreorderPlatform.Service.ViewModels.CampaignDetail;
using PreorderPlatform.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.Services.CampaignDetailServices
{
    public class CampaignDetailService : ICampaignDetailService
    {
        private readonly ICampaignDetailRepository _campaignDetailRepository;
        private readonly IMapper _mapper;

        public CampaignDetailService(ICampaignDetailRepository campaignDetailRepository, IMapper mapper)
        {
            _campaignDetailRepository = campaignDetailRepository;
            _mapper = mapper;
        }

        public async Task<List<CampaignDetailViewModel>> GetCampaignDetailsAsync()
        {
            try
            {
                var campaignDetails = await _campaignDetailRepository.GetAllAsync();
                return _mapper.Map<List<CampaignDetailViewModel>>(campaignDetails);
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occurred while fetching campaign details.", ex);
            }
        }

        public async Task<CampaignDetailViewModel> GetCampaignDetailByIdAsync(int id)
        {
            try
            {
                var campaignDetail = await _campaignDetailRepository.GetByIdAsync(id);

                if (campaignDetail == null)
                {
                    throw new NotFoundException($"Campaign detail with ID {id} was not found.");
                }

                return _mapper.Map<CampaignDetailViewModel>(campaignDetail);
            }
            catch (NotFoundException)
            {
                // Rethrow NotFoundException to be handled by the caller
                throw;
            }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while fetching campaign detail with ID {id}.", ex);
            }
        }

        public async Task<CampaignDetailViewModel> CreateCampaignDetailAsync(CampaignDetailCreateViewModel model)
        {
            try
            {
                var campaignDetail = _mapper.Map<CampaignDetail>(model);
                await _campaignDetailRepository.CreateAsync(campaignDetail);
                return _mapper.Map<CampaignDetailViewModel>(campaignDetail);
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occurred while creating the campaign detail.", ex);
            }
        }

        public async Task UpdateCampaignDetailAsync(CampaignDetailUpdateViewModel model)
        {
            try
            {
                var campaignDetail = await _campaignDetailRepository.GetByIdAsync(model.Id);
                campaignDetail = _mapper.Map(model, campaignDetail);
                await _campaignDetailRepository.UpdateAsync(campaignDetail);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while updating campaign detail with ID {model.Id}.", ex);
            }
        }

        public async Task DeleteCampaignDetailAsync(int id)
        {
            try
            {
                var campaignDetail = await _campaignDetailRepository.GetByIdAsync(id);
                await _campaignDetailRepository.DeleteAsync(campaignDetail);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while deleting campaign detail with ID {id}.", ex);
            }
        }
    }
}