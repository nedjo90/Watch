using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IProfessionalStatusRepository
{
    Task<IEnumerable<ProfessionalStatus>> GetAllAsync(bool trackChanges);
    Task<ProfessionalStatus?> GetById(Guid? id, bool trackChanges);
    Task<ProfessionalStatus?> GetByLabel(string? label, bool trackChanges);
    void CreateAsync(ProfessionalStatus professionalStatus);
    Task<IEnumerable<ProfessionalStatus>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges);
    void DeleteEntity(ProfessionalStatus entity);
    Task<PagedList<ProfessionalStatus>> GetAllPagingAsync(ProfessionalStatusParameters trainingTypeParameters, bool trackChanges);

}