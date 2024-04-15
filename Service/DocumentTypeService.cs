using Contracts;
using Entities.Models;
using Service.Contracts;

namespace Service;

internal sealed class DocumentTypeService : IDocumentTypeService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _loggerManager;

    public DocumentTypeService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
    {
        _repositoryManager = repositoryManager;
        _loggerManager = loggerManager;
    }
    public IEnumerable<DocumentType> GetAllDocumentTypes(bool trackChanges)
    {
        try
        {
            IEnumerable<DocumentType> documentTypes = 
                _repositoryManager.DocumentType.GetAllDocumentTypes(trackChanges);
            return documentTypes;
        }
        catch (Exception e)
        {
            _loggerManager.LogError($"Something went wrong in the {nameof(GetAllDocumentTypes)} service method {e}");
            throw;
        }
    }
}