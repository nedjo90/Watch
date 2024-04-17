using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class DocumentTypeRepository : RepositoryBase<DocumentType>, IDocumentTypeRepository
{
    public DocumentTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<DocumentType>> GetAllDocumentTypesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(c => c.Label)
            .ToListAsync();
    }
    
    public async Task<PagedList<DocumentType>> GetAllDocumentTypesPagingAsync
    (DocumentTypeParameters documentTypeParameters,
        bool trackChanges)
    {
        IEnumerable<DocumentType> documentTypes = await FindAll(trackChanges)
            .Search(documentTypeParameters.SearchTerm ?? string.Empty)
            .OrderBy(c => c.Label)
            .ToListAsync();
        int count = await FindAll(trackChanges)
            .Search(documentTypeParameters.SearchTerm ?? string.Empty)
            .CountAsync();
        return PagedList<DocumentType>
            .ToPagedList(documentTypes, count,documentTypeParameters.PageNumber, documentTypeParameters.PageSize);
    }
    
    public async Task<DocumentType?> GetDocumentTypeAsync(Guid documentTypeId, bool trackChanges)
    {
        return await
            FindByCondition
                (c => c.Id.Equals(documentTypeId), trackChanges)
                .SingleOrDefaultAsync();
    }

    public void CreateDocumentType(DocumentType? documentType)
    {
        Create(documentType);
    }

    public async Task<IEnumerable<DocumentType>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        return await FindByCondition(x => ids.Contains(x.Id), trackChanges).ToListAsync();
    }

    public void DeleteDocumentType(DocumentType documentType)
    {
        Delete(documentType);
    }
}