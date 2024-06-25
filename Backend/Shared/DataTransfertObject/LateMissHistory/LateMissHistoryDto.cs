namespace Shared.DataTransfertObject.LateMissHistory;

public record LateMissHistoryDto
{
    public Guid Id { get; init; }
    public string? ModifierUserId { get; init; }
    public string? TypeOfModification { get; init; }
    public DateTime DateOfModification { get; init; }
    public DateTime DeclarationDate { get; init; }    
    public DateTime StartDate { get; init; }    
    public DateTime EndDate { get; init; }
    public Guid LateMissTypeId { get; init; }    
    public Guid LateMissStatusId { get; init; }
    public string? UserId { get; init; }
}