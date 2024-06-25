using System.Runtime.InteropServices;
using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransfertObject.LateMissTypeHistory;

namespace Service;

internal class LateMissTypeHistoryService: ServiceBase, ILateMissTypeHistoryService
{
    public LateMissTypeHistoryService(IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }

    public async Task<IEnumerable<LateMissTypeHistoryDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<LateMissTypeHistory> lateMissTypeHistories =
            await RepositoryManager.LateMissTypeHistoryRepository.GetAllAsync(trackChanges);
        IEnumerable<LateMissTypeHistoryDto> lateMissTypeHistoryDtos =
            Mapper.Map<IEnumerable<LateMissTypeHistoryDto>>(lateMissTypeHistories);
        return lateMissTypeHistoryDtos;
    }

    public async Task RegisterModification(LateMissType lateMissType, string typeOfModification)
    {
        LateMissTypeHistory lateMissTypeHistory = new LateMissTypeHistory();
        lateMissTypeHistory.ModifierUserId = await ServiceManager.UserService.GetUserIdByUserName();
        lateMissTypeHistory.Label = lateMissType.Label!;
        lateMissTypeHistory.LateMissTypeId = lateMissType.Id;
        lateMissTypeHistory.TypeOfModification = typeOfModification;
        lateMissTypeHistory.DateOfModification = DateTime.UtcNow;
        RepositoryManager.LateMissTypeHistoryRepository.RegisterModification(lateMissTypeHistory);
    }
}