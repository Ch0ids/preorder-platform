using AutoMapper;
using PreorderPlatform.Service.ViewModels.Business.Request;
using PreorderPlatform.Service.ViewModels.Business.Response;
using PreorderPlatform.Service.ViewModels.BusinessPaymentCredential;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.ViewModels.AutoMapperProfile
{
    public static class BusinessPaymentCredentialMapper
    {
        public static void ConfigBusinessPaymentCredentialMapper(this IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<PreorderPlatform.Entity.Entities.BusinessPaymentCredential, BusinessPaymentCredentialCreateViewModel>().ReverseMap();
            configuration.CreateMap<PreorderPlatform.Entity.Entities.BusinessPaymentCredential, BusinessPaymentCredentialUpdateViewModel>().ReverseMap();
            configuration.CreateMap<PreorderPlatform.Entity.Entities.BusinessPaymentCredential, BusinessPaymentCredentialViewModel>().ReverseMap();
        }
    }
}
