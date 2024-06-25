using Shared.DataTransfertObject.Document;

namespace Service.Contracts;

public interface IDocumentService
{
    Task<DocumentDto> GetByIdAsync(Guid id, bool trackChanges);
    Task<IEnumerable<DocumentDto>> GetAllAsync(bool trackChanges);
    Task<IEnumerable<DocumentDto>> GetCollectionAsync(IEnumerable<Guid?> ids,bool trackChanges);

    Task<DocumentDto> CreateAsync(DocumentForCreationDto documentForCreationDto);
    Task<IEnumerable<DocumentDto>> CreateCollectionAsync(IEnumerable<DocumentForCreationDto> documentForCreationDtos);

}