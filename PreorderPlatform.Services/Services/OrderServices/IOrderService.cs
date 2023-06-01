using PreorderPlatform.Entity.Entities;
using PreorderPlatform.Service.ViewModels.Order;
using PreorderPlatform.Service.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.Services.OrderServices
{
    public interface IOrderService
    {
        Task<OrderViewModel> CreateOrderAsync(OrderCreateViewModel model);
        Task DeleteOrderAsync(int id);
        Task<OrderViewModel> GetOrderByIdAsync(int id);
        Task<List<OrderViewModel>> GetOrdersAsync();
        Task UpdateOrderAsync(OrderUpdateViewModel model);
    }
}
