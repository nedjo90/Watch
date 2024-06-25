using Entities.Models;
using Shared.DataTransfertObject.TrainingTypeHistory;

namespace Service.Contracts;

public interface ITrainingTypeHistoryService
{
    Task<IEnumerable<TrainingTypeHistoryDto>> GetAllAsync(bool trackChanges);
    Task RegisterModification( TrainingType trainingType, string typeOfModification);
}