using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransfertObject.LateMissHistory;
using Shared.DataTransfertObject.LateMissStatus;

namespace Service;

internal class LateMissHistoryService: ServiceBase, ILateMissHistoryService
{
    public LateMissHistoryService(IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }

    public async Task<IEnumerable<LateMissHistoryDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<LateMissHistory> lateMissHistories =
            await RepositoryManager.LateMissHistoryRepository.GetAllAsync(trackChanges);
        IEnumerable<LateMissHistoryDto> lateMissHistoryDtos =
            Mapper.Map<IEnumerable<LateMissHistoryDto>>(lateMissHistories);
        return lateMissHistoryDtos;
    }

    public async Task RegisterModification(LateMiss lateMiss, string typeOfModification)
    {
        LateMissHistory lateMissHistory = Mapper.Map<LateMissHistory>(lateMiss);
        lateMissHistory.ModifierUserId = await ServiceManager.UserService.GetUserIdByUserName();
        lateMissHistory.LateMissId = lateMiss.Id;
        lateMissHistory.TypeOfModification = typeOfModification;
        lateMissHistory.DateOfModification = DateTime.UtcNow;
        RepositoryManager.LateMissHistoryRepository.RegisterModification(lateMissHistory);
    }
}