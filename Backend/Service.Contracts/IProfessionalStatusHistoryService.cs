using Entities.Models;
using Shared.DataTransfertObject.ProfessionalStatus;
using Shared.DataTransfertObject.ProfessionalStatusHistory;

namespace Service.Contracts;

public interface IProfessionalStatusHistoryService
{
    Task<IEnumerable<ProfessionalStatusHistoryDto>> GetAllAsync(bool trackChanges);
    Task RegisterModification( ProfessionalStatus professionalStatus, string typeOfModification);
}