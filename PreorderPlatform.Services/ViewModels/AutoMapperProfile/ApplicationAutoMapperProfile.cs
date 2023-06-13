using AutoMapper;
using PreorderPlatform.Service.ViewModels.Business.Request;
using PreorderPlatform.Service.ViewModels.Business.Response;
using PreorderPlatform.Service.ViewModels.BusinessPaymentCredential;
using PreorderPlatform.Service.ViewModels.Campaign.Request;
using PreorderPlatform.Service.ViewModels.Campaign.Response;
using PreorderPlatform.Service.ViewModels.CampaignPrice.Request;
using PreorderPlatform.Service.ViewModels.CampaignPrice.Response;
using PreorderPlatform.Service.ViewModels.Category;
using PreorderPlatform.Service.ViewModels.Order;
using PreorderPlatform.Service.ViewModels.OrderItem;
using PreorderPlatform.Service.ViewModels.Payment;
using PreorderPlatform.Service.ViewModels.Product.Request;
using PreorderPlatform.Service.ViewModels.Product.Response;
using PreorderPlatform.Service.ViewModels.Role;
using PreorderPlatform.Service.ViewModels.User.Request;
using PreorderPlatform.Service.ViewModels.User.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.ViewModels.AutoMapperProfile
{
    public class ApplicationAutoMapperProfile : Profile
    {
        public ApplicationAutoMapperProfile()
        {
            // User mappings
            CreateMap<PreorderPlatform.Entity.Entities.User, UserResponse>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.BusinessName, opt => opt.MapFrom(src => src.Business.Name))
                .ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.User, UserUpdateRequest>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.User, UserCreateRequest>().ReverseMap();

            //Role mappings
            CreateMap<PreorderPlatform.Entity.Entities.Role, RoleCreateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Role, RoleDetailViewModel>().ReverseMap();

            //Category
            CreateMap<PreorderPlatform.Entity.Entities.Category, CategoryCreateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Category, CategoryUpdateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Category, CategoryViewModel>().ReverseMap();

            //Product
            CreateMap<PreorderPlatform.Entity.Entities.Product, ProductCreateRequest>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Product, ProductUpdateRequest>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Product, ProductResponse>()
                                                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                                                .ReverseMap();

            //Business
            CreateMap<PreorderPlatform.Entity.Entities.Business, BusinessCreateRequest>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Business, BusinessUpdateRequest>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Business, BusinessResponse>().ReverseMap();

            //BussinessPaymentCrential
            CreateMap<PreorderPlatform.Entity.Entities.BusinessPaymentCredential, BusinessPaymentCredentialCreateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.BusinessPaymentCredential, BusinessPaymentCredentialUpdateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.BusinessPaymentCredential, BusinessPaymentCredentialViewModel>().ReverseMap();

            //Campaign
            CreateMap<PreorderPlatform.Entity.Entities.Campaign, CampaignCreateRequest>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Campaign, CampaignUpdateRequest>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Campaign, CampaignResponse>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Campaign, CampaignDetailResponse>().ReverseMap();            


            //CampaignDetail
            CreateMap<PreorderPlatform.Entity.Entities.CampaignDetail, CampaignPriceCreateRequest>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.CampaignDetail, CampaignPriceUpdateRequest>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.CampaignDetail, CampaignPriceResponse>().ReverseMap();

            //Order
            CreateMap<PreorderPlatform.Entity.Entities.Order, OrderCreateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Order, OrderUpdateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Order, OrderViewModel>().ReverseMap();

            //OrderItem
            CreateMap<PreorderPlatform.Entity.Entities.OrderItem, OrderItemCreateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.OrderItem, OrderItemUpdateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.OrderItem, OrderItemViewModel>().ReverseMap();

            //Payment
            CreateMap<PreorderPlatform.Entity.Entities.Payment, PaymentCreateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Payment, PaymentUpdateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Payment, PaymentViewModel>().ReverseMap();

            // Add other mappings here as needed
        }
    }
}
