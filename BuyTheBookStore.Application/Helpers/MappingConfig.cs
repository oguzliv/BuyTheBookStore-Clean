using AutoMapper;
using BuyTheBookStore.Application.Dtos.BookAPIDtos;
using BuyTheBookStore.Application.Dtos.UserAPIDtos;
using BuyTheBookStore.BuyTheBookStore.Core.Entities;
using BuyTheBookStore.Core.Entities;

namespace BuyTheBookStore.Application
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps(){
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<UserDto, User>().ForMember(
                    dest=> dest.RoleText,
                    opt=>opt.MapFrom(src => src.IsAdmin == true ? "ADMIN" : "CUSTOMER"));
                config.CreateMap<User, UserDto>().ForMember(
                    dest => dest.IsAdmin,
                    opt => opt.MapFrom(src => src.Role == 0));
                config.CreateMap<UserResultDto, User>().ForMember(
                    dest => dest.RoleText,
                    opt => opt.MapFrom(src => src.IsAdmin == true ? "ADMIN" : "CUSTOMER"));
                config.CreateMap<User, UserResultDto>().ForMember(
                    dest => dest.IsAdmin,
                    opt => opt.MapFrom(src => src.Role == 0));
                config.CreateMap<User, RegisterDto>().ForMember(
                    dest => dest.IsAdmin, 
                    opt => opt.MapFrom(src => src.Role == 0));

                config.CreateMap<RegisterDto, User>().ForMember(
                    dest => dest.RoleText, 
                    opt => opt.MapFrom(src => src.IsAdmin == true ? "ADMIN" : "CUSTOMER"));

                config.CreateMap<CustomerUpdateDto, User>().ReverseMap();
                config.CreateMap<BookDto, Book>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
