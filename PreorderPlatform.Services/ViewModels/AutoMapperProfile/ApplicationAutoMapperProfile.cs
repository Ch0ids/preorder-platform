using AutoMapper;
using PreorderPlatform.Service.ViewModels.Role;
using PreorderPlatform.Service.ViewModels.User;
using PreorderPlatform.Services.ViewModels.User;
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
            CreateMap<PreorderPlatform.Entity.Entities.User, UserViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.User, UserUpdateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.User, UserCreateViewModel>().ReverseMap();

            //Role mappings

            CreateMap<PreorderPlatform.Entity.Entities.Role, RoleCreateViewModel>().ReverseMap();
            CreateMap<PreorderPlatform.Entity.Entities.Role, RoleDetailViewModel>().ReverseMap();

            //Product

            // Add other mappings here as needed
        }
    }
}
