using Entities.Models;

namespace Contracts;

public interface ITrainingTypeHistoryRepository
{
    Task<IEnumerable<TrainingTypeHistory>> GetAllAsync(bool trackChanges);
    void RegistreModification(TrainingTypeHistory trainingTypeHistory);
}