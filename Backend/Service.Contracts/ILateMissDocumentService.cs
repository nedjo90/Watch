using Shared.DataTransfertObject.LateMissDocument;

namespace Service.Contracts;

public interface ILateMissDocumentService
{
    Task<LateMissDocumentDto> GetByIdAsync(Guid id, bool trackChanges);
    Task<IEnumerable<LateMissDocumentDto>> GetAllAsync(bool trackChanges);
    Task<IEnumerable<LateMissDocumentDto>> GetCollectionAsync(IEnumerable<Guid?> ids,bool trackChanges);
    Task<LateMissDocumentDto> CreateAsync(LateMissDocumentForCreationDto lateMissDocumentForCreationDto);
    Task<IEnumerable<LateMissDocumentDto>> CreateCollectionAsync(IEnumerable<LateMissDocumentForCreationDto> lateMissDocumentForCreationDtos);
}