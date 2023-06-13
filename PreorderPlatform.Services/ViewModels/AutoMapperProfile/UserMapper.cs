using AutoMapper;
using PreorderPlatform.Service.ViewModels.User.Request;
using PreorderPlatform.Service.ViewModels.User.Response;

namespace PreorderPlatform.Service.ViewModels.AutoMapperProfile
{
    public static class UserMapper
    {
        public static void ConfigUserMapper(this IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<PreorderPlatform.Entity.Entities.User, UserResponse>()
    .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
    .ForMember(dest => dest.BusinessName, opt => opt.MapFrom(src => src.Business.Name))
    .ReverseMap();
            configuration.CreateMap<PreorderPlatform.Entity.Entities.User, UserUpdateRequest>().ReverseMap();
            configuration.CreateMap<PreorderPlatform.Entity.Entities.User, UserCreateRequest>().ReverseMap();
        }
    }
}
