using Contracts;
using Entities.Models;
using Shared.RequestFeatures;

namespace Repository;

public class ProfessionalStatusRepository : RepositoryBase<ProfessionalStatus>,IProfessionalStatusRepository
{
    public ProfessionalStatusRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    public Task<IEnumerable<ProfessionalStatus>> GetAllAsync(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<ProfessionalStatus?> GetById(Guid? id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public void CreateAsync(ProfessionalStatus newLabel)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProfessionalStatus>> GetCollectionAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        throw new NotImplementedException();
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