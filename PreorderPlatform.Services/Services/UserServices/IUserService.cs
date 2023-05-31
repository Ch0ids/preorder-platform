using PreorderPlatform.Entity.Entities;
using PreorderPlatform.Service.ViewModels.User;
using PreorderPlatform.Services.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Services.Services.UserServices
{
    internal interface IUserService
    {
        Task CreateUserAsync(UserCreateViewModel model);
        Task DeleteUserAsync(int id);
        Task<UserViewModel> GetUserByIdAsync(int id);
        Task<List<UserViewModel>> GetUsersAsync();
        Task UpdateUserAsync(UserUpdateViewModel model);
    }
}
