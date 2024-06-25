namespace Entities.Models;

public class ProfessionalStatusHistory : HistoryBase
{
    //ProfessionalStatus
    public Guid ProfessionalStatusId { get; set; }
    public ProfessionalStatus ProfessionalStatus { get; set; }
    public string Label { get; set; }
}