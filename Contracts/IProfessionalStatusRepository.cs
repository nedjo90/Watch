using System.Collections;
using Entities.Models;
using Shared.ProfessionalStatus;

namespace Contracts;

public interface IProfessionalStatusRepository
{
    Task<ProfessionalStatus?> GetProfessionalStatusByIdAsync(Guid id, bool trackChanges);
    void CreateProfessionalStatus(ProfessionalStatus professionalStatus);
    Task<IEnumerable<ProfessionalStatus>> GetAllProfessionalStatusAsync(bool trackChanges);
    Task<IEnumerable<ProfessionalStatus>> GetProfessionalStatusCollectionAsync
        (IEnumerable<Guid> ids, bool trackChanges);
    Task<IEnumerable<ProfessionalStatus>> GetProfessionalStatusCollectionAsync
        (IEnumerable<ProfessionalStatusDto> professionalStatus, bool trackChanges);
    void DeleteProfessionalStatusAsync(ProfessionalStatus entity);

}