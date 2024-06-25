namespace Shared.RequestFeatures;

public class LateMissStatusParameters : RequestParameters
{
    public string? SearchTerm { get; set; }

    public LateMissStatusParameters()
    {
        OrderBy = "Label";
    }
}