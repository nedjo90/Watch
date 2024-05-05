using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IDocumentStatusRepository
{
    Task<IEnumerable<DocumentStatus>> GetAllAsync(bool trackChanges);
    Task<DocumentStatus?> GetById(Guid? id, bool trackChanges);
    void CreateAsync(DocumentStatus newLabel);
    Task<IEnumerable<DocumentStatus>> GetCollectionAsync(IEnumerable<Guid> ids, bool trackChanges);
    void DeleteEntity(DocumentStatus entity);
    Task<PagedList<DocumentStatus>> GetAllPagingAsync(DocumentStatusParameters trainingTypeParameters, bool trackChanges);
}