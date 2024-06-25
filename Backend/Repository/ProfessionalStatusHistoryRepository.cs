using System.Collections.Immutable;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransfertObject.ProfessionalStatus;
using ProfessionalStatusHistory = Entities.Models.ProfessionalStatusHistory;

namespace Repository;

public class ProfessionalStatusHistoryRepository : RepositoryBase<ProfessionalStatusHistory>, IProfessionalStatusHistoryRepository
{
    public ProfessionalStatusHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<ProfessionalStatusHistory>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public void RegistreModification(ProfessionalStatusHistory professionalStatusHistory)
    {
        Create(professionalStatusHistory);
    }
}