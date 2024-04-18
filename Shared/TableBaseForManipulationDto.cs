namespace Shared;

public abstract record TableBaseForManipulationDto
{
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public Guid CreatedBy { get; set; }
    public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    public Guid UpdateBy { get; set; }
}