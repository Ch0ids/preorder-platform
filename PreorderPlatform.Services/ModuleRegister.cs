using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PreorderPlatform.Entity;
using PreorderPlatform.Entity.Repositories;
using PreorderPlatform.Service.Services;
using PreorderPlatform.Service.Services.AuthService;
using PreorderPlatform.Service.Services.BusinessPaymentCredentialServices;
using PreorderPlatform.Service.Services.BusinessServices;
using PreorderPlatform.Service.Services.CampaignDetailServices;
using PreorderPlatform.Service.Services.CampaignServices;
using PreorderPlatform.Service.Services.CategoryServices;
using PreorderPlatform.Service.Services.OrderItemServices;
using PreorderPlatform.Service.Services.OrderServices;
using PreorderPlatform.Service.Services.PaymentServices;
using PreorderPlatform.Service.Services.ProductServices;
using PreorderPlatform.Service.Services.RoleServices;
using PreorderPlatform.Services.Services.AuthService;
using PreorderPlatform.Services.Services.RoleServices;
using PreorderPlatform.Services.Services.UserServices;

namespace PreorderPlatform.Service
{
    public static class ModuleRegister
    {
        public static void RegisterBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterRepository();
            services.RegisterService();
            services.RegisterData(configuration);
        }

        public static void RegisterService(this IServiceCollection services)
        {
            services.AddScoped<IBusinessService, BusinessService>();
            services.AddScoped<IBusinessPaymentCredentialService, BusinessPaymentCredentialService>();
            services.AddScoped<ICampaignService, CampaignService>();
            services.AddScoped<ICampaignDetailService, CampaignDetailService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtService, JwtService>();

        }
    }
}
