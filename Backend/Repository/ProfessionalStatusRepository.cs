using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository;

public class ProfessionalStatusRepository : RepositoryBase<ProfessionalStatus>, IProfessionalStatusRepository
{
    public ProfessionalStatusRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    public async Task<IEnumerable<ProfessionalStatus>> GetAllAsync(bool trackChanges)
    {
        return await FindAll(false).ToListAsync();
    }

    public async Task<ProfessionalStatus?> GetById(Guid? id, bool trackChanges)
    {
        return await FindByCondition(e =>
            e.Id.Equals(id), trackChanges)
            .FirstOrDefaultAsync();
    }

    public async Task<ProfessionalStatus?> GetByLabel(string? label, bool trackChanges)
    {
        return await FindByCondition(e =>
            e.Label!.Equals(label), trackChanges).FirstOrDefaultAsync();
    }

    public void CreateAsync(ProfessionalStatus professionalStatus)
    {
        Create(professionalStatus);
    }

    public async Task<IEnumerable<ProfessionalStatus>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges)
    {
        return await FindByCondition(e => ids.Contains(e.Id), trackChanges).ToListAsync();
    }

    public void DeleteEntity(ProfessionalStatus entity)
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<ProfessionalStatus>> GetAllPagingAsync(ProfessionalStatusParameters trainingTypeParameters, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    
}