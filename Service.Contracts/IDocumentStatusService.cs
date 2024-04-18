using Shared;
using Shared.DocumentStatus;

namespace Service.Contracts;

public interface IDocumentStatusService
{
    Task<IEnumerable<DocumentStatusDto>> GetAllDocumentStatusAsync(bool trackChanges);
    Task<DocumentStatusDto> CreateDocumentStatusAsync
        (DocumentStatusForCreationDto documentStatusForCreationDto);

    public Task<DocumentStatusDto> GetDocumentById(Guid documentStatusId, bool trackChanges);

}