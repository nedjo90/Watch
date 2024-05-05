using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface ITrainingTypeRepository
{
    Task<IEnumerable<TrainingType>> GetAllAsync(bool trackChanges);
    Task<TrainingType?> GetById(Guid? id, bool trackChanges);
    void CreateAsync(TrainingType newLabel);
    Task<IEnumerable<TrainingType>> GetCollectionAsync(IEnumerable<Guid> ids, bool trackChanges);
    void DeleteEntity(TrainingType entity);
    Task<PagedList<TrainingType>> GetAllPagingAsync(TrainingTypeParameters trainingTypeParameters, bool trackChanges);
}