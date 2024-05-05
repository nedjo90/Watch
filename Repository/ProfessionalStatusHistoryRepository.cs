using Contracts;
using Entities.Models;

namespace Repository;

public class ProfessionalStatusHistoryRepository : RepositoryBase<ProfessionalStatusHistory>, IProfessionalStatusHistoryRepository
{
    public ProfessionalStatusHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}