﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreorderPlatform.Entity.Entities;
using PreorderPlatform.Services.Services.AuthService;
using PreorderPlatform.Services.Services.UserServices;
using PreorderPlatform.Services.ViewModels.ApiResponse;
using PreorderPlatform.Services.ViewModels.User;
using PreorderPlatform.Services.Services.Exceptions;
using PreorderPlatform.Services.Exceptions;

namespace PreorderPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UsersController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetUsersAsync();
                return Ok(new ApiResponse<List<UserViewModel>>(users, "Users fetched successfully.", true, null));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<object>(null, $"Error fetching users: {ex.Message}", false, null));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                return Ok(new ApiResponse<UserViewModel>(user, "User fetched successfully.", true, null));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ApiResponse<string>(null, ex.Message, false, null));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<object>(null, $"Error fetching user: {ex.Message}", false, null));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateViewModel model)
        {
            try
            {
                await _userService.CreateUserAsync(model);
                return CreatedAtAction(nameof(GetUserById), new { id = model.Id }, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<object>(null, $"Error creating user: {ex.Message}", false, null));
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateViewModel model)
        {
            try
            {
                await _userService.UpdateUserAsync(model);
                return Ok(new ApiResponse<object>(null, "User updated successfully.", true, null));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ApiResponse<object>(null, ex.Message, false, null));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<object>(null, $"Error updating user: {ex.Message}", false, null));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return Ok(new ApiResponse<object>(null, "User deleted successfully.", true, null));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ApiResponse<string>(null, ex.Message, false, null));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ApiResponse<object>(null, $"Error deleting user: {ex.Message}", false, null));
            }
        }
    }
}