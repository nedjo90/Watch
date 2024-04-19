namespace Entities.Exceptions;

public class CollectionBadRequest : BadRequestException
{
    public CollectionBadRequest(string message) : base($"{message} collection sent from a client is null.")
    {
    }
}