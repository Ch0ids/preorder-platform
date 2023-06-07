using AutoMapper;
using PreorderPlatform.Service.ViewModels.Business;
using PreorderPlatform.Service.ViewModels.BusinessPaymentCredential;
using PreorderPlatform.Service.ViewModels.Campaign;
using PreorderPlatform.Service.ViewModels.CampaignItem;
using PreorderPlatform.Service.ViewModels.Category;
using PreorderPlatform.Service.ViewModels.Order;
using PreorderPlatform.Service.ViewModels.OrderItem;
using PreorderPlatform.Service.ViewModels.Payment;
using PreorderPlatform.Service.ViewModels.Product;
using PreorderPlatform.Service.ViewModels.Role;
using PreorderPlatform.Service.ViewModels.User;
using PreorderPlatform.Service.ViewModels.User;
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
            CreateMap<PreorderPlatform.Entity.Entities.User, UserViewModel>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.BusinessName, opt => opt.MapFrom(src => src.Business.Name))

                .ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.User, UserUpdateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.User, UserCreateViewModel>().ReverseMap();

            //Role mappings
            CreateMap<PreorderPlatform.Entity.Entities.Role, RoleCreateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Role, RoleDetailViewModel>().ReverseMap();

            //Category
            CreateMap<PreorderPlatform.Entity.Entities.Category, CategoryCreateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Category, CategoryUpdateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Category, CategoryViewModel>().ReverseMap();

            //Product
            CreateMap<PreorderPlatform.Entity.Entities.Product, ProductCreateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Product, ProductUpdateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Product, ProductViewModel>()
                                                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                                                .ReverseMap();

            //Business
            CreateMap<PreorderPlatform.Entity.Entities.Business, BusinessCreateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Business, BusinessUpdateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Business, BusinessViewModel>().ReverseMap();

            //BussinessPaymentCrential
            CreateMap<PreorderPlatform.Entity.Entities.BusinessPaymentCredential, BusinessPaymentCredentialCreateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.BusinessPaymentCredential, BusinessPaymentCredentialUpdateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.BusinessPaymentCredential, BusinessPaymentCredentialViewModel>().ReverseMap();

            //Campaign
            CreateMap<PreorderPlatform.Entity.Entities.Campaign, CampaignCreateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Campaign, CampaignUpdateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Campaign, CampaignViewModel>()            
                                .ForMember(dest => dest.Business, opt => opt.MapFrom(src => src.Business))
                                .ForMember(dest => dest.BusinessName, opt => opt.MapFrom(src => src.Business.Name))
                                .ForMember(dest => dest.CampaignDetails, opt => opt.MapFrom(src => src.CampaignDetails))
                                .ReverseMap();

            //CampaignDetail
            CreateMap<PreorderPlatform.Entity.Entities.CampaignDetail, CampaignItemCreateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.CampaignDetail, CampaiugnItemUpdateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.CampaignDetail, CampaignItemViewModel>().ReverseMap();

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
