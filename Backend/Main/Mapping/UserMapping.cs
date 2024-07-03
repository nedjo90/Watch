using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.User;

namespace Main.Mapping;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<UserInfoDto, User>();
        CreateMap<User, UserInfoDto>();
    }
}