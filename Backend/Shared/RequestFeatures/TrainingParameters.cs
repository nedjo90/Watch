namespace Shared.RequestFeatures;

public class TrainingParameters : RequestParameters
{
    public string? SearchTerm { get; set; }

    public TrainingParameters()
    {
        OrderBy = "Label";
    }
}