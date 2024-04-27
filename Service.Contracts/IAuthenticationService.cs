using Microsoft.AspNetCore.Identity;
using Shared.Login;

namespace Service.Contracts;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto);
    Task<Dictionary<string, Dictionary<string, Dictionary<string, string>>>> 
        RegisterUserCollection(IEnumerable<UserForRegistrationDto> userForRegistrationDto);
    Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto);
    Task<TokenDto> CreateToken(bool populateExp);
}