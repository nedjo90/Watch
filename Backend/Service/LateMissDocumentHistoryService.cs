using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransfertObject.LateMissDocumentHistory;

namespace Service;

internal class LateMissDocumentHistoryService: ServiceBase, ILateMissDocumentHistoryService
{
    public LateMissDocumentHistoryService(IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }

    public async Task<IEnumerable<LateMissDocumentHistoryDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<LateMissDocumentHistory> lateMissDocumentHistories =
            await RepositoryManager.LateMissDocumentHistoryRepository.GetAllAsync(trackChanges);
        IEnumerable<LateMissDocumentHistoryDto> lateMissDocumentHistoryDtos =
            Mapper.Map<IEnumerable<LateMissDocumentHistoryDto>>(lateMissDocumentHistories);
        return lateMissDocumentHistoryDtos;
    }

    public async Task RegisterModification(LateMissDocument lateMissDocument, string typeOfModification)
    {
        LateMissDocumentHistory lateMissDocumentHistory = Mapper.Map<LateMissDocumentHistory>(lateMissDocument);
        lateMissDocumentHistory.ModifierUserId = await ServiceManager.UserService.GetUserIdByUserName();
        lateMissDocumentHistory.LateMissDocumentId = lateMissDocument.Id;
        lateMissDocumentHistory.TypeOfModification = typeOfModification;
        lateMissDocumentHistory.DateOfModification = DateTime.UtcNow;
        RepositoryManager.LateMissDocumentHistoryRepository.RegisterModification(lateMissDocumentHistory);
    }
}