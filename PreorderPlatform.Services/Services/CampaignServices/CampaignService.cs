using AutoMapper;
using PreorderPlatform.Entity.Entities;
using PreorderPlatform.Entity.Repositories.CampaignRepositories;
using PreorderPlatform.Service.ViewModels.Campaign;
using PreorderPlatform.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.Services.CampaignServices
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IMapper _mapper;

        public CampaignService(ICampaignRepository campaignRepository, IMapper mapper)
        {
            _campaignRepository = campaignRepository;
            _mapper = mapper;
        }

        public async Task<List<CampaignViewModel>> GetCampaignsAsync()
        {
            try
            {
                var campaigns = await _campaignRepository.GetAllAsync();
                return _mapper.Map<List<CampaignViewModel>>(campaigns);
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occurred while fetching campaigns.", ex);
            }
        }

        //GetAllCampaignsWithOwnerAndBusinessAndCampaignDetailsAsync
        public async Task<List<CampaignViewModel>> GetAllCampaignsWithOwnerAndBusinessAndCampaignDetailsAsync()
        {
            try
            {
                var campaigns = await _campaignRepository.GetAllCampaignsWithOwnerAndBusinessAndCampaignDetailsAsync();
                return _mapper.Map<List<CampaignViewModel>>(campaigns);
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occurred while fetching campaigns.", ex);
            }
        }
        public async Task<CampaignViewModel> GetCampaignByIdAsync(int id)
        {
            try
            {
                var campaign = await _campaignRepository.GetByIdAsync(id);

                if (campaign == null)
                {
                    throw new NotFoundException($"Campaign with ID {id} was not found.");
                }

                return _mapper.Map<CampaignViewModel>(campaign);
            }
            catch (NotFoundException)
            {
                // Rethrow NotFoundException to be handled by the caller
                throw;
            }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while fetching campaign with ID {id}.", ex);
            }
        }

        public async Task<CampaignViewModel> CreateCampaignAsync(CampaignCreateViewModel model)
        {
            try
            {
                var campaign = _mapper.Map<Campaign>(model);
                await _campaignRepository.CreateAsync(campaign);
                return _mapper.Map<CampaignViewModel>(campaign);
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occurred while creating the campaign.", ex);
            }
        }

        public async Task UpdateCampaignAsync(CampaignUpdateViewModel model)
        {
            try
            {
                var campaign = await _campaignRepository.GetByIdAsync(model.Id);
                campaign = _mapper.Map(model, campaign);
                await _campaignRepository.UpdateAsync(campaign);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while updating campaign with ID {model.Id}.", ex);
            }
        }

        public async Task DeleteCampaignAsync(int id)
        {
            try
            {
                var campaign = await _campaignRepository.GetByIdAsync(id);
                await _campaignRepository.DeleteAsync(campaign);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while deleting campaign with ID {id}.", ex);
            }
        }
    }
}