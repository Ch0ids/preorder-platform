using AutoMapper;
using PreorderPlatform.Service.ViewModels.Business.Request;
using PreorderPlatform.Service.ViewModels.Business.Response;
using PreorderPlatform.Service.ViewModels.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.ViewModels.AutoMapperProfile
{
    public static class PaymentMapper
    {
        public static void ConfigPaymentMapper(this IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<PreorderPlatform.Entity.Entities.Payment, PaymentCreateViewModel>().ReverseMap();
            configuration.CreateMap<PreorderPlatform.Entity.Entities.Payment, PaymentUpdateViewModel>().ReverseMap();
            configuration.CreateMap<PreorderPlatform.Entity.Entities.Payment, PaymentViewModel>().ReverseMap();
        }
    }
}
