using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransfertObject.DocumentTypeHistory;

namespace Service;

internal class DocumentTypeHistoryService : ServiceBase, IDocumentTypeHistoryService
{
    public DocumentTypeHistoryService(IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }

    public async Task<IEnumerable<DocumentTypeHistoryDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<DocumentTypeHistory> documentTypeHistories =
            await RepositoryManager.DocumentTypeHistoryRepository.GetAllAsync(trackChanges);
        IEnumerable<DocumentTypeHistoryDto> documentTypeHistoryDtos =
            Mapper.Map<IEnumerable<DocumentTypeHistoryDto>>(documentTypeHistories);
        return documentTypeHistoryDtos;
    }

    public async Task RegisterModification(DocumentType documentType, string typeOfModification)
    {
        DocumentTypeHistory documentTypeHistory = new DocumentTypeHistory();
        documentTypeHistory.ModifierUserId = await ServiceManager.UserService.GetUserIdByUserName();
        documentTypeHistory.Label = documentType.Label!;
        documentTypeHistory.DocumentTypeId = documentType.Id;
        documentTypeHistory.TypeOfModification = typeOfModification;
        documentTypeHistory.DateOfModification = DateTime.UtcNow;
        RepositoryManager.DocumentTypeHistoryRepository.RegisterModification(documentTypeHistory);
    }
}