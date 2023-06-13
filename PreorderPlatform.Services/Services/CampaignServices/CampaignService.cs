﻿using AutoMapper;
using PreorderPlatform.Entity.Entities;
using PreorderPlatform.Entity.Repositories.CampaignRepositories;
using PreorderPlatform.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PreorderPlatform.Service.Utility.Pagination;
using PreorderPlatform.Service.ViewModels.Campaign.Response;
using PreorderPlatform.Service.ViewModels.Campaign.Request;
using PreorderPlatform.Service.Enum;
using Microsoft.EntityFrameworkCore;
using PreorderPlatform.Service.Utility;

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

        public async Task<List<CampaignResponse>> GetCampaignsAsync()
        {
            try
            {
                var campaigns = await _campaignRepository.GetAllAsync();
                return _mapper.Map<List<CampaignResponse>>(campaigns);
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occurred while fetching campaigns.", ex);
            }
        }

        //GetAllCampaignsWithOwnerAndBusinessAndCampaignDetailsAsync
        public async Task<List<CampaignResponse>> GetAllCampaignsWithOwnerAndBusinessAndCampaignDetailsAsync()
        {
            try
            {
                var campaigns = await _campaignRepository.GetAllCampaignsWithOwnerAndBusinessAndCampaignDetailsAsync();
                return _mapper.Map<List<CampaignResponse>>(campaigns);
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occurred while fetching campaigns.", ex);
            }
        }
        public async Task<CampaignResponse> GetCampaignByIdAsync(int id)
        {
            try
            {
                var campaign = await _campaignRepository.GetByIdAsync(id);

                if (campaign == null)
                {
                    throw new NotFoundException($"Campaign with ID {id} was not found.");
                }

                return _mapper.Map<CampaignResponse>(campaign);
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

        public async Task<CampaignResponse> CreateCampaignAsync(CampaignCreateRequest model)
        {
            try
            {
                var campaign = _mapper.Map<Campaign>(model);
                await _campaignRepository.CreateAsync(campaign);
                return _mapper.Map<CampaignResponse>(campaign);
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occurred while creating the campaign.", ex);
            }
        }

        public async Task UpdateCampaignAsync(CampaignUpdateRequest model)
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

        public IList<CampaignResponse> Get(PaginationParam<CampaignEnum.CampaignSort> paginationModel, CampaignSearchRequest filterModel)
        {
            try
            {
                var query = _campaignRepository.Table
                    .GetWithSearch(filterModel) //theo thứ tự search
                    .GetWithSorting(paginationModel.SortKey.ToString(), paginationModel.SortOrder) //sort
                    .GetWithPaging(paginationModel.Page, paginationModel.PageSize)  // phân trang
                    .AsQueryable();

                var result = _mapper.ProjectTo<CampaignResponse>(query);

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occurred while fetching campaigns.", ex);
            }
        }
    }
}