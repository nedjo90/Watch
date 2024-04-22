using Entities.Models;
using Shared.ProfessionalStatus;

namespace Service.Contracts;

public interface IProfessionalStatusService
{
    Task<ProfessionalStatusDto> GetProfessionalStatusByIdAsync(Guid id, bool trackChanges);
    Task<IEnumerable<ProfessionalStatusDto>> GetAllProfessionalStatusAsync(bool trackChanges);
    Task<IEnumerable<ProfessionalStatusDto>> GetProfessionalStatusCollectionAsync(string ids, bool trackChanges);
    Task<ProfessionalStatusDto> CreateProfessionalStatusAsync
        (ProfessionalStatusForCreation professionalStatusForCreation);
    Task<IEnumerable<ProfessionalStatusDto>> CreateProfessionalStatusCollectionAsync
        (IEnumerable<ProfessionalStatusForCreation> professionalStatusForCreations, bool trackChanges);

    Task<IEnumerable<ProfessionalStatus>> GetProfessionalStatusCollectionAsync
        (IEnumerable<ProfessionalStatusDto> professionalStatus, bool trackChanges);

    Task DeleteProfessionalStatus(Guid id, bool trackChanges);
    Task DeleteProfessionalStatusCollection(IEnumerable<ProfessionalStatusDto> professionalStatusDto, bool trackChanges);
    Task UpdateProfessionalStatusAsync
        (Guid id, ProfessionalStatusForUpdateDto professionalStatusForUpdateDto, bool trackChanges);
}