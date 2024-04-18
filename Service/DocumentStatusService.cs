using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared;
using Shared.DocumentStatus;

namespace Service;

internal sealed class DocumentStatusService : ServiceBase, IDocumentStatusService
{
    public DocumentStatusService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper, IDocumentTypeLinks documentTypeLinks)
        : base(repositoryManager, loggerManager, mapper, documentTypeLinks) {}
    
    
    public async Task<IEnumerable<DocumentStatusDto>> GetAllDocumentStatusAsync(bool trackChanges)
    {
        IEnumerable<DocumentStatus> documentStatus =
            await RepositoryManager.DocumentStatus.GetAllDocumentStatusAsync(trackChanges);
        IEnumerable<DocumentStatusDto> documentStatusDto = Mapper.Map<IEnumerable<DocumentStatusDto>>(documentStatus);
        return documentStatusDto;
    }

    public async Task<DocumentStatusDto> CreateDocumentStatusAsync(DocumentStatusForCreationDto documentStatusForCreationDto)
    {
        DocumentStatus? documentStatus = Mapper.Map<DocumentStatus>(documentStatusForCreationDto);
        RepositoryManager.DocumentStatus.CreateDocumentStatusAsync(documentStatus);
        await RepositoryManager.SaveAsync();
        DocumentStatusDto? documentStatusDto = Mapper.Map<DocumentStatusDto>(documentStatus);
        return documentStatusDto;
    }

    public async Task<DocumentStatusDto> GetDocumentById(Guid documentStatusId, bool trackChanges)
    {
        DocumentStatus? documentStatus =
            await RepositoryManager.DocumentStatus.GetDocumentStatusById(documentStatusId, trackChanges);
        DocumentStatusDto documentStatusDto = Mapper.Map<DocumentStatusDto>(documentStatus);
        return documentStatusDto;
    }
}