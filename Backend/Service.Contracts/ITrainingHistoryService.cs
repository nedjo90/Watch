
using Entities.Models;
using Shared.DataTransfertObject.TrainingHistory;

namespace Service.Contracts;

public interface ITrainingHistoryService
{
    Task<IEnumerable<TrainingHistoryDto>> GetAllAsync(bool trackChanges);
    Task RegisterModification(Training training, string typeOfModification);
}