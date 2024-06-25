namespace Shared.RequestFeatures;

public class TrainingTypeParameters : RequestParameters
{
    public string? SearchTerm { get; set; }

    public TrainingTypeParameters()
    {
        OrderBy = "Label";
    }
}