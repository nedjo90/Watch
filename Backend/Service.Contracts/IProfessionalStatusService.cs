using Entities.LinkModels;
using Entities.Models;
using Shared.DataTransfertObject.ProfessionalStatus;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IProfessionalStatusService
{
    Task<IEnumerable<ProfessionalStatusDto>> GetAllAsync(bool trackChanges);
    Task<ProfessionalStatusDto> GetByIdAsync(Guid guid, bool trackChanges);
    Task<ProfessionalStatus?> CheckIfExistAndGetById(Guid? id, bool trackChanges);
    Task<IEnumerable<ProfessionalStatusDto>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges);
    Task<ProfessionalStatusDto> CreateAsync(ProfessionalStatusForCreationDto professionalStatusForCreation);
    Task<IEnumerable<ProfessionalStatusDto>> CreateCollectionAsync(IEnumerable<ProfessionalStatusForCreationDto> professionalStatusForCreationDtos);
}