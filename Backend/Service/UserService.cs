using System.Security.Claims;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;

namespace Service;

internal class UserService: ServiceBase, IUserService
{
    public UserService(UserManager<User> userManager,IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(userManager,httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }
    
    public async Task<IList<string>> GetCurrentUserRoles()
    {
        User? user = UserManager.FindByNameAsync(HttpContextAccessor.HttpContext.User.Identity?.Name ?? string.Empty).Result;
        if (user is not null)
        {
            IList<string> roles = await UserManager.GetRolesAsync(user);
            return roles;
        }

        return [];
    }
    
    public async Task<User?> GetCurrentUser()
    {
        User? user = await UserManager.GetUserAsync(HttpContextAccessor.HttpContext.User);
        return user;
    }
    
    
    public async Task<string> GetUserIdByUserName(string? userName, bool trackChanges)
    {
        string? userId = await RepositoryManager.UserRepository.GetUserIdByName(userName, false);
        if (userId is null)
            throw new UserIdNotFoundBadRequest();
        return userId;
    }
    
    public async Task<string> GetUserIdByUserName()
    {
        return await GetUserIdByUserName(HttpContextAccessor.HttpContext.User.Identity?.Name, false);
    }

    public Task<bool> CheckIfUserIdIsExisting(Guid? id)
    {
        return CheckIfUserIdIsExisting(id.ToString());
    }

    public async Task<bool> CheckIfUserIdIsExisting(string? id)
    {
        User? user =
            await RepositoryManager.UserRepository.GetUserByIdAsync(id, false);
        return user != null;
    }
}