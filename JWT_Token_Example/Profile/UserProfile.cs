using Authentication_Login.Dtos.LoginUsers;
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
            CreateMap<LoginUserDto, Users>().ReverseMap();
            CreateMap<LoginUserDto, UserDto>().ReverseMap();
        }
    }
}
