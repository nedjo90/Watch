using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.ProfessionalStatus;

namespace Repository;

public class ProfessionalStatusRepository : RepositoryBase<ProfessionalStatus>, IProfessionalStatusRepository
{
    public ProfessionalStatusRepository(RepositoryContext repositoryContext) : base(repositoryContext) {}

    public async Task<ProfessionalStatus?> GetProfessionalStatusByIdAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(e => e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
    }

    public void CreateProfessionalStatus(ProfessionalStatus professionalStatus)
    {
        Create(professionalStatus);
    }

    public async Task<IEnumerable<ProfessionalStatus>> GetAllProfessionalStatusAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(e => e.Label)
            .ToListAsync();
    }
    public async Task<IEnumerable<ProfessionalStatus>> GetProfessionalStatusCollectionAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        return 
            await FindByCondition(e => ids.Contains(e.Id), trackChanges)
            .ToListAsync();
    }
    public async Task<IEnumerable<ProfessionalStatus>> GetProfessionalStatusCollectionAsync
        (IEnumerable<ProfessionalStatusDto> professionalStatus, bool trackChanges)
    {
        IEnumerable<Guid> ids = professionalStatus.Select(c => c.Id);
        return await GetProfessionalStatusCollectionAsync(ids, trackChanges);
    }
    public void DeleteProfessionalStatusAsync(ProfessionalStatus entity)
    {
        Delete(entity);
    }
}