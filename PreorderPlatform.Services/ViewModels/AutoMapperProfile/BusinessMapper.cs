using AutoMapper;
using PreorderPlatform.Entity.Entities;
using PreorderPlatform.Service.ViewModels.Business.Request;
using PreorderPlatform.Service.ViewModels.Business.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.ViewModels.AutoMapperProfile
{
    public static class BusinessMapper
    {
        public static void ConfigBusinessMapper(this IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<PreorderPlatform.Entity.Entities.Business, BusinessCreateRequest>().ReverseMap();
            configuration.CreateMap<PreorderPlatform.Entity.Entities.Business, BusinessUpdateRequest>().ReverseMap();
            configuration.CreateMap<PreorderPlatform.Entity.Entities.Business, BusinessResponse>().ReverseMap();
        }
    }
}
