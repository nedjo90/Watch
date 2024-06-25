using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IDocumentStatusRepository
{
    Task<IEnumerable<DocumentStatus>> GetAllAsync(bool trackChanges);
    Task<DocumentStatus?> GetByIdAsync(Guid? id, bool trackChanges);
    Task<DocumentStatus?> GetByLabelAsync(string? label, bool trackChanges);
    void CreateAsync(DocumentStatus documentStatus);
    Task<IEnumerable<DocumentStatus>> GetCollectionAsync(IEnumerable<Guid?> ids, bool trackChanges);
    void DeleteEntity(DocumentStatus entity);
    Task<PagedList<DocumentStatus>> GetAllPagingAsync(DocumentStatusParameters trainingTypeParameters, bool trackChanges);
}