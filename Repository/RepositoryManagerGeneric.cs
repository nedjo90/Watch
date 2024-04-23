using Contracts;
using Entities.Models;

namespace Repository;

public class RepositoryManagerGeneric<T> : RepositoryManager, IRepositoryManagerGeneric<T> where T : BasicGenericEntity
{
    private readonly Lazy<IBasicGenericRepository<T>> _basicRepository;
    public IBasicGenericRepository<T> BasicGenericRepository => _basicRepository.Value;
    
    public RepositoryManagerGeneric(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        _basicRepository = new Lazy<IBasicGenericRepository<T>>(new BasicGenericRepository<T>(repositoryContext));
    }
    
}