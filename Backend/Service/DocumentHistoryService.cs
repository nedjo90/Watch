using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.DataTransfertObject.DocumentHistory;

namespace Service;

internal class DocumentHistoryService :ServiceBase, IDocumentHistoryService
{
    public DocumentHistoryService(UserManager<User?> userManager,IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base( userManager,httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
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

    public async Task RegisterModification(Document document, string typeOfModification, string? userId = null)
    {
        DocumentHistory documentHistory = Mapper.Map<DocumentHistory>(document);
        if (userId.IsNullOrEmpty())
            documentHistory.ModifierUserId = await ServiceManager.UserService.GetUserIdByUserName();
        documentHistory.Label = document.Label!;
        documentHistory.DocumentId = document.Id;
        documentHistory.TypeOfModification = typeOfModification;
        documentHistory.DateOfModification = DateTime.UtcNow;
        RepositoryManager.DocumentHistoryRepository.RegisterForModification(documentHistory);
    }
}