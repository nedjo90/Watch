using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;

namespace Service;

internal class UserHistoryService : ServiceBase, IUserHistoryService
{
    public UserHistoryService(UserManager<User?> userManager,IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(userManager, httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }
}