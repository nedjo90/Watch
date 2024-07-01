using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransfertObject.LateMissStatusHistory;

namespace Service;

internal class LateMissStatusHistoryService : ServiceBase, ILateMissStatusHistoryService
{
    public LateMissStatusHistoryService(UserManager<User?> userManager,IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(userManager, httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }

    public async Task<IEnumerable<LateMissStatusHistoryDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<LateMissStatusHistory> lateMissStatusHistories =
            await RepositoryManager.LateMissStatusHistoryRepository.GetAllAsync(trackChanges);
        IEnumerable<LateMissStatusHistoryDto> lateMissStatusHistoryDtos =
            Mapper.Map<IEnumerable<LateMissStatusHistoryDto>>(lateMissStatusHistories);
        return lateMissStatusHistoryDtos;
    }

    public async Task RegisterModification(LateMissStatus lateMissStatus, string typeOfModification)
    {
        LateMissStatusHistory lateMissStatusHistory = new LateMissStatusHistory();
        lateMissStatusHistory.ModifierUserId = await ServiceManager.UserService.GetUserIdByUserName();
        lateMissStatusHistory.Label = lateMissStatus.Label!;
        lateMissStatusHistory.LateMissStatusId = lateMissStatus.Id;
        lateMissStatusHistory.TypeOfModification = typeOfModification;
        lateMissStatusHistory.DateOfModification = DateTime.UtcNow;
        RepositoryManager.LateMissStatusHistoryRepository.RegisterModification(lateMissStatusHistory);
    }
}