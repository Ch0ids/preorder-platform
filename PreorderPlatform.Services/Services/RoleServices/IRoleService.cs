using Microsoft.EntityFrameworkCore;
using PreorderPlatform.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.Services.RoleServices
{
<<<<<<< HEAD:PreorderPlatform.Entity/Repositories/UserRepository/UserRepository.cs
    public class UserRepository : RepositoryBase<User>
=======
    public interface IRoleService
>>>>>>> 24cded826e037883fb1bcc0c6819e3e8d14e838d:PreorderPlatform.Services/Services/RoleServices/IRoleService.cs
    {
        private readonly PreOrderSystemContext _context;

        public UserRepository(PreOrderSystemContext context) : base(context)
        {
            _context = context;
        }

        // Add any additional methods specific to the user entity if needed

        public async Task<User> ValidateUserCredentials(string email, string password)
        {
            // Thực hiện kiểm tra tên đăng nhập và mật khẩu
            // Trả về đối tượng User nếu thông tin đăng nhập hợp lệ
            // Trả về null nếu thông tin đăng nhập không hợp lệ

            var user = await _context.Users
                .Include(u => u.Role) // Include the Role entity when querying the User
                .SingleOrDefaultAsync(u => u.Email == email);

            if (user == null || !VerifyPassword(password, user.Password))
            {
                return null;
            }

            return user;
        }

        private bool VerifyPassword(string password, string passwordHash)
        {
            // Thực hiện kiểm tra mật khẩu và mã hóa mật khẩu
            // Trả về true nếu mật khẩu hợp lệ, ngược lại trả về false

            // Ví dụ sử dụng BCrypt
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }

    }
}