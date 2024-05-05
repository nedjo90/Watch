namespace Shared.RequestFeatures;

public class DocumentStatusParameters : RequestParameters
{
    public string? SearchTerm { get; set; }

    public DocumentStatusParameters()
    {
        OrderBy = "Label";
    }
}