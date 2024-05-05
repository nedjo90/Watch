using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Http;
using Service.Contracts;

namespace Service;

internal class ProfessionalStatusService : ServiceBase, IProfessionalStatusService
{
    public ProfessionalStatusService(IHttpContextAccessor httpContext, IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper) : base(httpContext, repositoryManager, loggerManager, mapper)
    {
    }
}