using Authentication_Login.Dtos.Users;
using Authentication_Login.Models;
using AutoMapper;

namespace Authentication_Login
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Users, GetUserDto>().ReverseMap();
            CreateMap<Users, CreateUserDto>().ReverseMap();
            CreateMap<Users, UserDto>().ReverseMap();
            CreateMap<CreateUserDto, UserDto>().ReverseMap();
        }
    }
}
