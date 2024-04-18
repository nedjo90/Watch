using Contracts;
using Repository.Extensions;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IDocumentTypeRepository> _documentTypeRepository;
    private readonly Lazy<IDocumentStatusRepository> _documentStatusRepository;
    
    
    public IDocumentStatusRepository DocumentStatus => _documentStatusRepository.Value;
    public IDocumentTypeRepository DocumentType => _documentTypeRepository.Value;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _documentTypeRepository = 
            new Lazy<IDocumentTypeRepository>(() => new DocumentTypeRepository(repositoryContext));
        _documentStatusRepository = 
            new Lazy<IDocumentStatusRepository>(() => new DocumentStatusRepository(repositoryContext));
    }


    public async Task SaveAsync()
    {
        await _repositoryContext.SaveChangesAsync();
    }
}