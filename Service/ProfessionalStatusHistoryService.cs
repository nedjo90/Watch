using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Http;

namespace Service;

internal class ProfessionalStatusHistoryService : ServiceBase, IProfessionalStatusHistoryService
{
    public ProfessionalStatusHistoryService(IHttpContextAccessor httpContext, IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper) : base(httpContext, repositoryManager, loggerManager, mapper)
    {
    }
}