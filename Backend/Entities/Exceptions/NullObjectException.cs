namespace Entities.Exceptions;

public class NullObjectException : BadRequestException
{
    public NullObjectException(string message) : base(message)
    {
    }
}