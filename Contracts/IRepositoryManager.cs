namespace Contracts;

public interface IRepositoryManager
{
    public IDocumentTypeRepository DocumentType { get; }
    public IDocumentStatusRepository DocumentStatus { get; }
    
    public IProfessionalStatusRepository ProfessionalStatus { get; }
    
    Task SaveAsync();
  
}