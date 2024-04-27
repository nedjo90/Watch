using AutoMapper;
using Entities.Models;
using Shared.Login;

namespace Main.Mapping;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<UserForRegistrationDto, User>();
    }
}