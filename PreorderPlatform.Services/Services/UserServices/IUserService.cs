﻿using PreorderPlatform.Entity.Entities;
using PreorderPlatform.Service.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.Services.UserServices
{
    public interface IUserService
    {
        Task<UserViewModel> CreateUserAsync(UserCreateViewModel model);
        Task DeleteUserAsync(int id);
        Task<UserViewModel> GetUserByIdAsync(int id);
        Task<List<UserViewModel>> GetUsersAsync();
        Task UpdateUserAsync(UserUpdateViewModel model);
    }
}
