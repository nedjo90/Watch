using System.Dynamic;
using Entities.LinkModels;
using Entities.Models;
using Shared;
using Shared.DocumentType;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IDocumentTypeService
{
    Task<IEnumerable<DocumentTypeDto>> GetAllDocumentTypesAsync(bool trackChanges);
    Task<(LinkResponse linkResponse, MetaData metadata)> GetAllDocumentTypesPagingAsync
    (LinkParameters linkParameters, bool trackChanges);
    Task<DocumentTypeDto> GetDocumentTypeAsync(Guid documentType, bool trackChanges);
    Task<DocumentTypeDto> CreateDocumentTypeAsync(DocumentTypeForCreationDto documentTypeForCreationDto);
    Task<IEnumerable<DocumentTypeDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    Task<(IEnumerable<DocumentTypeDto> documentTypeDtos, string ids)> CreateDocumentTypeCollectionAsync
        (IEnumerable<DocumentTypeForCreationDto> documentTypeCollection);
    Task DeleteDocumentTypeAsync(Guid documentTypeId, bool trackChanges);
    Task DeleteDocumentTypeCollectionAsync(IEnumerable<DocumentTypeDto> ids, bool trackChanges);
    Task UpdateDocumentTypeAsync(Guid documentTypeId, DocumentTypeForUpdateDto documentTypeForUpdateDto,
        bool trackChanges);
    Task<(DocumentTypeForUpdateDto documentTypeToPatch, DocumentType documentTypeEntity)> GetDocumentTypeForPatchAsync(
        Guid documentTypeId, bool trackChanges);
    Task SaveChangesForPatchAsync(DocumentTypeForUpdateDto documentTypeToPatch, DocumentType documentTypeEntity);
}