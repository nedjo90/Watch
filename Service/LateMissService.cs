using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;

namespace Service;

internal class LateMissService: ServiceBase, ILateMissService
{
    public LateMissService(IHttpContextAccessor httpContext, IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper) : base(httpContext, repositoryManager, loggerManager, mapper)
    {
    }
}