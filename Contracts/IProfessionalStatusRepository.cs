using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IProfessionalStatusRepository
{
    Task<IEnumerable<ProfessionalStatus>> GetAllAsync(bool trackChanges);
    Task<ProfessionalStatus?> GetById(Guid? id, bool trackChanges);
    void CreateAsync(ProfessionalStatus newLabel);
    Task<IEnumerable<ProfessionalStatus>> GetCollectionAsync(IEnumerable<Guid> ids, bool trackChanges);
    void DeleteEntity(ProfessionalStatus entity);
    Task<PagedList<ProfessionalStatus>> GetAllPagingAsync(ProfessionalStatusParameters trainingTypeParameters, bool trackChanges);
}