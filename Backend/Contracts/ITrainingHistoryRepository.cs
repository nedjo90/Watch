
using Entities.Models;

namespace Contracts;

public interface ITrainingHistoryRepository
{
    Task<IEnumerable<TrainingHistory>> GetAllAsync(bool trackChanges);
    void RegistreModification(TrainingHistory trainingHistory);
}