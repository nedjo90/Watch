using Microsoft.AspNetCore.Http;

namespace Entities.Exceptions;

public abstract class BadRequestException : Exception
{ 
    protected BadRequestException(string message) : base(message)
    {
        
    }
}