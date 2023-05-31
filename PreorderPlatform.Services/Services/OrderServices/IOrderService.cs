using PreorderPlatform.Entity.Entities;
using PreorderPlatform.Services.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.Services.OrderServices
{
    public interface IOrderService
    {
        public Task<List<UserViewModel>> GetUsersAsync();

    }
}
