namespace Entities.Exceptions;

public abstract class NotAllowedException : Exception
{
    public NotAllowedException(string message) : base(message)
    {
        
    }
}