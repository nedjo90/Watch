namespace Entities.Exceptions;

public class UserIdNotFoundBadRequest : BadRequestException
{
    public UserIdNotFoundBadRequest(string id) : base($"User id {id} is null, user id is mandatory to create, delete or update a table")
    {
    }
    
    public UserIdNotFoundBadRequest() : base($"User id is null, user id is mandatory to create, delete or update a table")
    {
    }
}