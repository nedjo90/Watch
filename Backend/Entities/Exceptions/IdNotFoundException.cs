namespace Entities.Exceptions;

public class IdNotFoundException : NotFoundException
{
    public IdNotFoundException(Guid? id, string label) : base($"{id} does not match any {label}")
    {
    }
    
}