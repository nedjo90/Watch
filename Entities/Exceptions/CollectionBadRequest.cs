namespace Entities.Exceptions;

public class CollectionBadRequest : BadRequestException
{
    public CollectionBadRequest() : base($"Collection sent from a client is null or invalid.")
    {
    }
}