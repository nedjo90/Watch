namespace Entities.Exceptions;

public class NotNullableException : BadRequestException
{
    public NotNullableException(string variable) : base($"{variable} cannot be null.")
    {
    }
}