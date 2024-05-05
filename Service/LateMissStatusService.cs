using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Http;
using Service.Contracts;

namespace Service;

internal class LateMissStatusService : ServiceBase, ILateMissStatusService
{
    public LateMissStatusService(IHttpContextAccessor httpContext, IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper) : base(httpContext, repositoryManager, loggerManager, mapper)
    {
    }
}