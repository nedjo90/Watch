namespace Entities.Exceptions;

public abstract class ForbiddenRequestException : Exception
{
    public ForbiddenRequestException(string message) : base(message)
    {
    }
}