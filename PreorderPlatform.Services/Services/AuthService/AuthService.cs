﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PreorderPlatform.Entity.Models;
using PreorderPlatform.Entity.Repositories.UserRepositories;
using PreorderPlatform.Entity.Repositories.UserRepository;
using PreorderPlatform.Service.Services.AuthService;
using PreorderPlatform.Service.ViewModels.User.Request;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.Services.AuthService
{
    internal class AuthService : IAuthService
    {
        private readonly string _jwtSecret;
        // Thêm DataContext nếu bạn sử dụng Entity Framework Core
        private readonly IUserRepository _userRepository;

        public AuthService(IConfiguration configuration, IUserRepository userRepository)
        {
            _jwtSecret = configuration.GetSection("Jwt:Secret").Value;
            _userRepository = userRepository;
        }

        // Các phương thức khác liên quan đến xác thực và đăng nhập

        public async Task<User> LoginService(LoginRequest loginViewModel)
        {
            // Thực hiện kiểm tra tên đăng nhập và mật khẩu
            // Trả về đối tượng User nếu thông tin đăng nhập hợp lệ
            // Trả về null nếu thông tin đăng nhập không hợp lệ

            var user = await _userRepository.ValidateUserCredentials(loginViewModel.Email, loginViewModel.Password);

            return user;
        }

        
    }
}
