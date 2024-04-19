namespace Entities.Exceptions;

public class DocumentStatusNotFoundException : NotFoundException
{
    public DocumentStatusNotFoundException(Guid guid) 
        : base($"The Document Status with id: {guid} doesn't exist in the database")
    {
    }
}