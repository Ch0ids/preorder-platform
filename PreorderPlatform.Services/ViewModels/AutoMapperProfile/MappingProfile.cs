using AutoMapper;
using PreorderPlatform.Services.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Services.ViewModels.AutoMapperProfile
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
