namespace Entities.Exceptions;

public class ProfessionalStatusNotFound : NotFoundException
{
    public ProfessionalStatusNotFound(Guid guid) : base(
        $"The professional status with id: {guid} doesn't exist in the database"
    )
    {
    }
}