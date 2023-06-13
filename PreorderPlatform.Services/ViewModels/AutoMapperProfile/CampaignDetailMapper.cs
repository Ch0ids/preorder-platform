using AutoMapper;
using PreorderPlatform.Service.ViewModels.Business.Request;
using PreorderPlatform.Service.ViewModels.Business.Response;
using PreorderPlatform.Service.ViewModels.CampaignPrice.Request;
using PreorderPlatform.Service.ViewModels.CampaignPrice.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.ViewModels.AutoMapperProfile
{
    public static class CampaignDetailMapper
    {
        public static void ConfigCampaignDetailMapper(this IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<PreorderPlatform.Entity.Entities.CampaignDetail, CampaignPriceCreateRequest>().ReverseMap();
            configuration.CreateMap<PreorderPlatform.Entity.Entities.CampaignDetail, CampaignPriceUpdateRequest>().ReverseMap();
            configuration.CreateMap<PreorderPlatform.Entity.Entities.CampaignDetail, CampaignPriceResponse>().ReverseMap();
        }
    }
}
