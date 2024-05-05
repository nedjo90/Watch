namespace Shared.RequestFeatures;

public class ProfessionalStatusParameters : RequestParameters
{
    public string? SearchTerm { get; set; }

    public ProfessionalStatusParameters()
    {
        OrderBy = "Label";
    }
}