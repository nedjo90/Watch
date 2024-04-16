namespace Entities.Exceptions;

public class DocumentTypeNotFoundException : NotFoundException
{
    public DocumentTypeNotFoundException(Guid guid) : base(
        $"The Document Type with id: {guid} doesn't exist in the database"
    )
    {
    }
}