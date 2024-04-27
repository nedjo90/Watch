using AutoMapper;
using Entities.Models;
using Shared.User;

namespace Main.Mapping;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<UserForRegistrationDto, User>();
    }
}