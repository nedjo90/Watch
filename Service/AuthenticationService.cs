using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Shared.User;

namespace Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;

    public AuthenticationService(ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
    {
        _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto)
    {
        User user = _mapper.Map<User>(userForRegistrationDto);
        IdentityResult result =
            await _userManager.CreateAsync(user, userForRegistrationDto.Password);
        if (result.Succeeded)
            await _userManager.AddToRolesAsync(user, userForRegistrationDto.Roles);
        return result;

    }
}