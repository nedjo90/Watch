namespace Shared.RequestFeatures;

public class BasicGenericParameters : RequestParameters
{
    public string? SearchTerm { get; set; }

    public BasicGenericParameters()
    {
        OrderBy = "Label";
    }
}