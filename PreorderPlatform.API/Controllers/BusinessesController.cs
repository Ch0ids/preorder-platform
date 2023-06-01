using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreorderPlatform.Service.Services.BusinessServices;
using PreorderPlatform.Service.ViewModels.ApiResponse;
using PreorderPlatform.Service.ViewModels.Business;
using PreorderPlatform.Service.Exceptions;

namespace PreorderPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessesController : ControllerBase
    {
        private readonly IBusinessService _businessService;
        private readonly IMapper _mapper;

        public BusinessesController(IBusinessService businessService, IMapper mapper)
        {
            _businessService = businessService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBusinesses()
        {
            try
            {
                var businesses = await _businessService.GetBusinessesAsync();
                return Ok(new ApiResponse<List<BusinessViewModel>>(businesses, "Businesses fetched successfully.", true, null));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<object>(null, $"Error fetching businesses: {ex.Message}", false, null));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusinessById(int id)
        {
            try
            {
                var business = await _businessService.GetBusinessByIdAsync(id);
                return Ok(new ApiResponse<BusinessViewModel>(business, "Business fetched successfully.", true, null));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ApiResponse<string>(null, ex.Message, false, null));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<object>(null, $"Error fetching business: {ex.Message}", false, null));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBusiness(BusinessCreateViewModel model)
        {
            try
            {
                var business = await _businessService.CreateBusinessAsync(model);

                return CreatedAtAction(nameof(GetBusinessById),
                                       new { id = business.Id },
                                       new ApiResponse<BusinessViewModel>(business, "Business created successfully.", true, null));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<object>(null, $"Error creating business: {ex.Message}", false, null));
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBusiness(BusinessUpdateViewModel model)
        {
            try
            {
                await _businessService.UpdateBusinessAsync(model);
                return Ok(new ApiResponse<object>(null, "Business updated successfully.", true, null));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ApiResponse<object>(null, ex.Message, false, null));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<object>(null, $"Error updating business: {ex.Message}", false, null));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusiness(int id)
        {
            try
            {
                await _businessService.DeleteBusinessAsync(id);
                return Ok(new ApiResponse<object>(null, "Business deleted successfully.", true, null));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ApiResponse<string>(null, ex.Message, false, null));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<object>(null, $"Error deleting business: {ex.Message}", false, null));
            }
        }
    }
}