namespace Entities.Exceptions;

public class ForbiddenForRegistrationRole : ForbiddenRequestException
{
    public ForbiddenForRegistrationRole() : base("Registration is not allowed for this role, you have to register with 'Candidate' role")
    {
    }
}