using AutoMapper;
using PreorderPlatform.Service.ViewModels.Business.Request;
using PreorderPlatform.Service.ViewModels.Business.Response;
using PreorderPlatform.Service.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.ViewModels.AutoMapperProfile
{
    public static class RoleMapper
    {
        public static void ConfigRoleMapper(this IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<PreorderPlatform.Entity.Entities.Role, RoleCreateViewModel>().ReverseMap();
            configuration.CreateMap<PreorderPlatform.Entity.Entities.Role, RoleDetailViewModel>().ReverseMap();
        }
    }
}
