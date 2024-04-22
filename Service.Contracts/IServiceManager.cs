namespace Service.Contracts;

public interface IServiceManager
{
    IDocumentTypeService DocumentType { get; }
    IDocumentStatusService DocumentStatus { get; }
    IProfessionalStatusService ProfessionalStatus { get; }
}