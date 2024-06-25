namespace Entities.Exceptions;

public class RoleBadRequestException : BadRequestException
{
    public RoleBadRequestException(string message) : base(message)
    {
    }
}