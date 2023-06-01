using PreorderPlatform.Entity.Entities;
using PreorderPlatform.Service.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.Services.AuthService
{
    public interface IAuthService
    {
        Task<User> LoginService(LoginViewModel loginViewModel);
        // Add other method signatures related to authentication and login
    }
}
