﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PreorderPlatform.Entity.Entities;
using PreorderPlatform.Entity.Repositories.BusinessPaymentCredentialRepositories;
using PreorderPlatform.Entity.Repositories.BusinessRepositories;
using PreorderPlatform.Entity.Repositories.CampaignDetailRepositories;
using PreorderPlatform.Entity.Repositories.CampaignRepositories;
using PreorderPlatform.Entity.Repositories.CategoryRepositories;
using PreorderPlatform.Entity.Repositories.OrderItemRepositories;
using PreorderPlatform.Entity.Repositories.OrderRepositories;
using PreorderPlatform.Entity.Repositories.PaymentRepositories;
using PreorderPlatform.Entity.Repositories.ProductRepositories;
using PreorderPlatform.Entity.Repositories.RoleRepositories;
using PreorderPlatform.Entity.Repositories.UserRepositories;

namespace PreorderPlatform.Entity
{
    public static class ModuleRegister
    {
        public static void RegisterData(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DBContext");
            services.AddDbContext<PreOrderSystemContext>(options
    => options.UseSqlServer(connectionString));
        }

        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IBusinessRepository, BusinessRepository>();
            services.AddScoped<IBusinessPaymentCredentialRepository, BusinessPaymentCredentialRepository>();
            services.AddScoped<ICampaignRepository, CampaignRepository>();
            services.AddScoped<ICampaignDetailRepository, CampaignDetailRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}