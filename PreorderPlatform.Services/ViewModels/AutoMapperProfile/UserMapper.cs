using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PreorderPlatform.Entity.Entities;
using PreorderPlatform.Services.ViewModels.User;

namespace PreorderPlatform.Services.ViewModels.AutoMapperProfile
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<PreorderPlatform.Entity.Entities.User, UserViewModel>();
            CreateMap<UserViewModel, PreorderPlatform.Entity.Entities.User>();
        }
    }
}
