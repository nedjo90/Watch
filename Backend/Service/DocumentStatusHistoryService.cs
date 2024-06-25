using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransfertObject.DocumentStatusHistory;

namespace Service;

internal class DocumentStatusHistoryService: ServiceBase, IDocumentStatusHistoryService
{
    public DocumentStatusHistoryService(IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }

    public async Task<IEnumerable<DocumentStatusHistoryDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<DocumentStatusHistory> documentStatusHistories =
            await RepositoryManager.DocumentStatusHistoryRepository.GetAllAsync(trackChanges);
        IEnumerable<DocumentStatusHistoryDto> documentStatusHistoryDtos =
            Mapper.Map<IEnumerable<DocumentStatusHistoryDto>>(documentStatusHistories);
        return documentStatusHistoryDtos;
    }

    public async Task RegisterModification(DocumentStatus documentStatus, string typeOfModification)
    {
        DocumentStatusHistory documentStatusHistory = new DocumentStatusHistory();
        documentStatusHistory.ModifierUserId = await ServiceManager.UserService.GetUserIdByUserName();
        documentStatusHistory.Label = documentStatus.Label!;
        documentStatusHistory.DocumentStatusId = documentStatus.Id;
        documentStatusHistory.TypeOfModification = typeOfModification;
        documentStatusHistory.DateOfModification = DateTime.UtcNow;
        RepositoryManager.DocumentStatusHistoryRepository.RegisterModification(documentStatusHistory);
    }
}