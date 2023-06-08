using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PreorderPlatform.Service.Exceptions;
using PreorderPlatform.Service.Services.CampaignServices;
using PreorderPlatform.Service.Utility.Pagination;
using PreorderPlatform.Service.ViewModels.ApiResponse;
using PreorderPlatform.Service.ViewModels.Campaign;

namespace PreorderPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {
        private readonly ICampaignService _campaignService;
        private readonly IMapper _mapper;

        public CampaignsController(ICampaignService campaignService, IMapper mapper)
        {
            _campaignService = campaignService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCampaigns(
            [FromQuery] PaginationParam paginationModel)
        {
            try
            {
                var campaigns = await _campaignService.GetAllCampaignsWithOwnerAndBusinessAndCampaignDetailsAsync(paginationModel);
                //need 1 more funct at service to get total pages & total items
                //no need param Contructor to pass data

                return Ok(new ApiResponse<List<CampaignViewModel>>
                    (
                    campaigns,
                    "Campaigns fetched successfully.",
                    true,
                    new PaginationInfo(0, paginationModel.PageSize, paginationModel.Page, 0)
                    )
                );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<object>(null, $"Error fetching campaigns: {ex.Message}", false, null));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCampaignById(int id)
        {
            try
            {
                var campaign = await _campaignService.GetCampaignByIdAsync(id);
                return Ok(new ApiResponse<CampaignViewModel>(campaign, "Campaign fetched successfully.", true, null));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ApiResponse<string>(null, ex.Message, false, null));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<object>(null, $"Error fetching campaign: {ex.Message}", false, null));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCampaign(CampaignCreateViewModel model)
        {
            try
            {
                var campaign = await _campaignService.CreateCampaignAsync(model);

                return CreatedAtAction(nameof(GetCampaignById),
                                       new { id = campaign.Id },
                                       new ApiResponse<CampaignViewModel>(campaign, "Campaign created successfully.", true, null));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<object>(null, $"Error creating campaign: {ex.Message}", false, null));
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCampaign(CampaignUpdateViewModel model)
        {
            try
            {
                await _campaignService.UpdateCampaignAsync(model);
                return Ok(new ApiResponse<object>(null, "Campaign updated successfully.", true, null));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ApiResponse<object>(null, ex.Message, false, null));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<object>(null, $"Error updating campaign: {ex.Message}", false, null));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampaign(int id)
        {
            try
            {
                await _campaignService.DeleteCampaignAsync(id);
                return Ok(new ApiResponse<object>(null, "Campaign deleted successfully.", true, null));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ApiResponse<string>(null, ex.Message, false, null));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<object>(null, $"Error deleting campaign: {ex.Message}", false, null));
            }
        }
    }
}