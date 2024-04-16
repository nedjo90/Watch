namespace Entities.Exceptions;

public class DocumentTypeCollectionBadRequest : BadRequestException
{
    public DocumentTypeCollectionBadRequest() : base("Document Type collection sent from a client is null.")
    {
    }
}