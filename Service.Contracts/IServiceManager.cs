namespace Service.Contracts;

public interface IServiceManager
{
    IDocumentTypeService DocumentTypeService { get; }
    IDocumentStatusService DocumentStatusService { get; }
}