using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;

namespace Service;

internal class DocumentTypeHistoryService : ServiceBase, IDocumentTypeHistoryService
{
    public DocumentTypeHistoryService(IHttpContextAccessor httpContext, IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper) : base(httpContext, repositoryManager, loggerManager, mapper)
    {
    }
}