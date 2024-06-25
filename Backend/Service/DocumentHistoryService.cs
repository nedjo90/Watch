using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransfertObject.DocumentHistory;

namespace Service;

internal class DocumentHistoryService :ServiceBase, IDocumentHistoryService
{
    public DocumentHistoryService(IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }

    public async Task<IEnumerable<DocumentHistoryDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<DocumentHistory> documentHistories =
            await RepositoryManager.DocumentHistoryRepository.GetAllAsync(trackChanges);
        IEnumerable<DocumentHistoryDto> documentHistoryDtos =
            Mapper.Map<IEnumerable<DocumentHistoryDto>>(documentHistories);
        return documentHistoryDtos;
    }

    public async Task RegisterModification(Document document, string typeOfModification)
    {
        DocumentHistory documentHistory = Mapper.Map<DocumentHistory>(document);
        documentHistory.ModifierUserId = await ServiceManager.UserService.GetUserIdByUserName();
        documentHistory.Label = document.Label!;
        documentHistory.DocumentId = document.Id;
        documentHistory.TypeOfModification = typeOfModification;
        documentHistory.DateOfModification = DateTime.UtcNow;
        RepositoryManager.DocumentHistoryRepository.RegisterForModification(documentHistory);
    }
}