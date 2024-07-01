using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransfertObject.TrainingTypeHistory;

namespace Service;

internal class TrainingTypeHistoryService: ServiceBase, ITrainingTypeHistoryService
{
    public TrainingTypeHistoryService(UserManager<User?> userManager,IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(userManager, httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }
    
    public async Task<IEnumerable<TrainingTypeHistoryDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<TrainingTypeHistory> trainingTypeHistory =
            await RepositoryManager.TrainingTypeHistoryRepository.GetAllAsync(trackChanges);
        IEnumerable<TrainingTypeHistoryDto> trainingTypeHistoryDto =
            Mapper.Map<IEnumerable<TrainingTypeHistoryDto>>(trainingTypeHistory);
        return trainingTypeHistoryDto;
    }
    

    public async Task RegisterModification(TrainingType trainingType,
        string typeOfModification)
    {
        TrainingTypeHistory trainingTypeHistory = new TrainingTypeHistory();
        trainingTypeHistory.ModifierUserId = await ServiceManager.UserService.GetUserIdByUserName();
        trainingTypeHistory.Label = trainingType.Label!;
        trainingTypeHistory.TrainingTypeId = trainingType.Id;
        trainingTypeHistory.TypeOfModification = typeOfModification;
        trainingTypeHistory.DateOfModification = DateTime.UtcNow;
        RepositoryManager.TrainingTypeHistoryRepository.RegistreModification(trainingTypeHistory);
    }
}