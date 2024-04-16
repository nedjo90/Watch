namespace Entities.Exceptions;

public class NullObjectException : BadRequestException
{
    public NullObjectException(string objectName) : base($"{objectName} object is null.")
    {
    }
}