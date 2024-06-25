using Entities.Models;
using Shared.DataTransfertObject.ProfessionalStatus;
using ProfessionalStatusHistory = Entities.Models.ProfessionalStatusHistory;

namespace Contracts;

public interface IProfessionalStatusHistoryRepository
{
    Task<IEnumerable<ProfessionalStatusHistory>> GetAllAsync(bool trackChanges);
    void RegistreModification(ProfessionalStatusHistory professionalStatusHistory);
}