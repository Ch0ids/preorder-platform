using AutoMapper;
using PreorderPlatform.Service.ViewModels.User;
using PreorderPlatform.Service.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.ViewModels.AutoMapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PreorderPlatform.Entity.Entities.User, UserCreateViewModel>();
            CreateMap<UserCreateViewModel, PreorderPlatform.Entity.Entities.User>();
        }
    }
}
