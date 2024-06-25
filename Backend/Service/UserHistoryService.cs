using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Http;
using Service.Contracts;

namespace Service;

internal class UserHistoryService : ServiceBase, IUserHistoryService
{
    public UserHistoryService(IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }
}