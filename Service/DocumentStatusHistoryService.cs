using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Http;
using Service.Contracts;

namespace Service;

internal class DocumentStatusHistoryService: ServiceBase, IDocumentStatusHistoryService
{
    public DocumentStatusHistoryService(IHttpContextAccessor httpContext, IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper) : base(httpContext, repositoryManager, loggerManager, mapper)
    {
    }
}