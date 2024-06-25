using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;

namespace Service;

internal class UserService: ServiceBase, IUserService
{
    public UserService(IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
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