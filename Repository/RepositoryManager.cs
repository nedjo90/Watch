using Contracts;
using Repository.Extensions;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IDocumentTypeRepository> _documentTypeRepository;
    private readonly Lazy<IDocumentStatusRepository> _documentStatusRepository;
    private readonly Lazy<IProfessionalStatusRepository> _professionalStatusRepository;
    
    public IDocumentStatusRepository DocumentStatus => _documentStatusRepository.Value;
    public IDocumentTypeRepository DocumentType => _documentTypeRepository.Value;
    public IProfessionalStatusRepository ProfessionalStatus => _professionalStatusRepository.Value;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _documentTypeRepository = 
            new Lazy<IDocumentTypeRepository>(() => new DocumentTypeRepository(repositoryContext));
        _documentStatusRepository = 
            new Lazy<IDocumentStatusRepository>(() => new DocumentStatusRepository(repositoryContext));
        _professionalStatusRepository =
            new Lazy<IProfessionalStatusRepository>(() => new ProfessionalStatusRepository(repositoryContext));
    }


    public async Task SaveAsync()
    {
        await _repositoryContext.SaveChangesAsync();
    }
}