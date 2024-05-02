using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.Login;

namespace Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IOptionsMonitor<JwtConfiguration> _configuration;
    private readonly JwtConfiguration _jwtConfiguration;
    private User? _user;

    public AuthenticationService(ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IOptionsMonitor<JwtConfiguration> configuration)
    {
        _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
        _configuration = configuration;
        _jwtConfiguration = new JwtConfiguration();
        _jwtConfiguration = _configuration.CurrentValue;
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

    public async Task<TokenDto> CreateToken(bool populateExp)
    {
        SigningCredentials signingCredentials = GetSigningCredentials();
        List<Claim> claims = await GetClaims();
        JwtSecurityToken jwtSecurityTokenOptions = GenerateTokenOptions(signingCredentials, claims);
        string refreshToken = GenerateRefreshToken();
        _user.RefreshToken = refreshToken;
        if(populateExp)
            _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
        await _userManager.UpdateAsync(_user);
        string? accessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityTokenOptions);
        return new TokenDto{AccessToken = accessToken, RefreshToken = refreshToken};
    }

    public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
    {
        ClaimsPrincipal princpial = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
        User? user = await _userManager.FindByNameAsync(princpial.Identity.Name);
        if (user == null
            || user.RefreshToken != tokenDto.RefreshToken
            || user.RefreshTokenExpiryTime <= DateTime.Now)
            throw new RefreshTokenBadRequest();
        _user = user;
        return await CreateToken(populateExp: false);
    }

    private SigningCredentials GetSigningCredentials()
    {
        byte[] key = Encoding.UTF8.GetBytes(_jwtConfiguration.Secret);
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
        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
        (
            issuer: _jwtConfiguration.ValidIssuer,
            audience: _jwtConfiguration.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtConfiguration.Expires)),
            signingCredentials: signingCredentials
        );
        return jwtSecurityToken;
    }

    private string GenerateRefreshToken()
    {
        byte[] randomNumber = new byte[32];
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }

    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        //IConfigurationSection jwtSettings = _jwtConfiguration.Section;
        TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtConfiguration.Secret)),
            ValidateLifetime = true,
            ValidIssuer = _jwtConfiguration.ValidIssuer,
            ValidAudience = _jwtConfiguration.ValidAudience
        };
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        ClaimsPrincipal? principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out
            securityToken);
        JwtSecurityToken? jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }
        return principal;
    }
}