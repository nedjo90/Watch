namespace Shared.RequestFeatures;

public class DocumentTypeParameters : RequestParameters
{
    public string? SearchTerm { get; set; }

    public DocumentTypeParameters()
    {
        OrderBy = "Label";
    }
}