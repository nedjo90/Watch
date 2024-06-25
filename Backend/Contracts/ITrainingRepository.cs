using Entities.Models;

namespace Contracts;

public interface ITrainingRepository
{
    Task<IEnumerable<Training>> GetAllAsync(bool trackChanges);
    Task<Training?> GetByIdAsync(Guid id, bool trackChanges);
    void CreateTraining(Training training);
}