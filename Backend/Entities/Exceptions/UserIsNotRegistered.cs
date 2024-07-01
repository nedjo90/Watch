namespace Entities.Exceptions;

public class UserIsNotRegistered : BadRequestException
{
    public UserIsNotRegistered() : base($"User is not registered")
    {
    }
}