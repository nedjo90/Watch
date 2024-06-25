using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransfertObject.TrainingHistory;

namespace Service;

internal class TrainingHistoryService: ServiceBase, ITrainingHistoryService
{
    public TrainingHistoryService(IHttpContextAccessor httpContextAccessor,IServiceManager serviceManager, IRepositoryManager repositoryManager,
        ILoggerManager loggerManager, IMapper mapper) : base(httpContextAccessor, serviceManager, repositoryManager,loggerManager, mapper)
    {
    }

    public async Task<IEnumerable<TrainingHistoryDto>> GetAllAsync(bool trackChanges)
    {
        IEnumerable<TrainingHistory> trainingHistories =
            await RepositoryManager.TrainingHistoryRepository.GetAllAsync(trackChanges);
        IEnumerable<TrainingHistoryDto> trainingHistoryDtos =
            Mapper.Map<IEnumerable<TrainingHistoryDto>>(trainingHistories);
        return trainingHistoryDtos;
    }

    public async Task RegisterModification(Training training, string typeOfModification)
    {
        TrainingHistory trainingHistory = new TrainingHistory();
        trainingHistory.ModifierUserId = await ServiceManager.UserService.GetUserIdByUserName();
        trainingHistory.TrainingId = training.Id;
        trainingHistory.TypeOfModification = typeOfModification;
        trainingHistory.DateOfModification = DateTime.UtcNow;
        trainingHistory.TrainingTypeId = training.TrainingTypeId;
        trainingHistory.StartDate = training.StartDate;
        trainingHistory.EndDate = training.EndDate;
        RepositoryManager.TrainingHistoryRepository.RegistreModification(trainingHistory);
    }
}