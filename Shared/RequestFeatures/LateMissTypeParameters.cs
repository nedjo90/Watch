namespace Shared.RequestFeatures;

public class LateMissTypeParameters : RequestParameters
{
    public string? SearchTerm { get; set; }

    public LateMissTypeParameters()
    {
        OrderBy = "Label";
    }
}