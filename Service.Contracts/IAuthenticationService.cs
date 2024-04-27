using Microsoft.AspNetCore.Identity;
using Shared.User;

namespace Service.Contracts;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto);
    Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto);
    Task<string> CreateToken();
}