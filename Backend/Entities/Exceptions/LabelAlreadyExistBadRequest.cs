namespace Entities.Exceptions;

public class LabelAlreadyExistBadRequest : BadRequestException
{
    public LabelAlreadyExistBadRequest(string table, string label) : base($"'{label}' label already exist for {table}.")
    {
    }
}