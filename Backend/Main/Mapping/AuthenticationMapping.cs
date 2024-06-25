using AutoMapper;
using Entities.Models;
using Shared.DataTransfertObject.Authentication;

namespace Main.Mapping;

public class AuthenticationMapping : Profile
{
    public AuthenticationMapping()
    {
        CreateMap<UserForRegistrationDto, User>();
    }
}