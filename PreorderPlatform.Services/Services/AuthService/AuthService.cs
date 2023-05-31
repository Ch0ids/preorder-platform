using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PreorderPlatform.Entity.Entities;
using PreorderPlatform.Entity.Repositories.UserRepository;
using PreorderPlatform.Services.ViewModels.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Services.Services.AuthService
{
    public class AuthService
    {
        private readonly string _jwtSecret;
        // Thêm DataContext nếu bạn sử dụng Entity Framework Core
        private readonly UserRepository _userRepository;

        public AuthService(IConfiguration configuration, UserRepository userRepository)
        {
            _jwtSecret = configuration.GetSection("Jwt:Secret").Value;
            _userRepository = userRepository;
        }

        // Các phương thức khác liên quan đến xác thực và đăng nhập

        public async Task<User> LoginService(LoginViewModel loginViewModel)
        {
            // Thực hiện kiểm tra tên đăng nhập và mật khẩu
            // Trả về đối tượng User nếu thông tin đăng nhập hợp lệ
            // Trả về null nếu thông tin đăng nhập không hợp lệ

            var user = await _userRepository.ValidateUserCredentials(loginViewModel.Email, loginViewModel.Password);

            return user;
        }

        
    }
}
