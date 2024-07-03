namespace Entities.Exceptions;

public class NotConnectedException : NotAllowedException
{
    public NotConnectedException() : base("Your are not connected to any session.")
    {
    }
}