namespace Shared.DataTransfertObject.ProfessionalStatusHistory;

public record ProfessionalStatusHistoryDto
{
    public Guid Id { get; init; }
    public string? ModifierUserId { get; init; }
    public string? TypeOfModification { get; init; }
    public DateTime DateOfModification { get; init; }
    public Guid ProfessionalStatusId { get; init; }
    public string? Label { get; init; }
}