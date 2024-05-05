using Entities.Models;
using Shared.Training;

namespace Contracts;

public interface ITrainingRepository
{
    Task<Training?> GetByIdAsync(Guid id, bool trackChanges);
    void CreateTraining(Training training);
}