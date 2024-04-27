using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.User;

namespace Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private User? _user;

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

    public async Task<Dictionary<string, Dictionary<string, Dictionary<string, string>>>> RegisterUserCollection(IEnumerable<UserForRegistrationDto> userForRegistrationDto)
    {
        Dictionary<string, Dictionary<string, Dictionary<string, string>>> results =
            new Dictionary<string, Dictionary<string, Dictionary<string, string>>>
            {
                ["Failed"] = new Dictionary<string, Dictionary<string, string>>()
            };
        foreach (UserForRegistrationDto userDto in userForRegistrationDto)
        {
            IdentityResult result = await RegisterUser(userDto);
            if (!result.Succeeded)
            {
                results["Failed"].Add(userDto.UserName, new Dictionary<string, string>());
                foreach (IdentityError error in result.Errors)
                {
                    results["Failed"][userDto.UserName].Add(error.Code, error.Description);
                }
            }
        }
        return results;
    }

    public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto)
    {
        _user = await _userManager.FindByNameAsync(userForAuthenticationDto.UserName);
        bool isValidUser = _user != null && await _userManager.CheckPasswordAsync(_user, userForAuthenticationDto.Password);
        if(!isValidUser)
            _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Wrong user name or password.");
        return isValidUser;
    }

    public async Task<string> CreateToken()
    {
        SigningCredentials signingCredentials = GetSigningCredentials();
        List<Claim> claims = await GetClaims();
        JwtSecurityToken jwtSecurityTokenOptions = GenerateTokenOptions(signingCredentials, claims);
        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityTokenOptions);
    }

    private SigningCredentials GetSigningCredentials()
    {
        byte[] key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings")["Secret"]!);
        SymmetricSecurityKey secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaims()
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, _user.UserName)
        };
        IList<string> roles = await _userManager.GetRolesAsync(_user);
        foreach (string role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        IConfigurationSection jwtSettings = _configuration.GetSection("JwtSettings");
        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
        (
            issuer: jwtSettings["ValidIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signingCredentials
        );
        return jwtSecurityToken;
    }
}