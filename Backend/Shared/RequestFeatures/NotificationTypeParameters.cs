namespace Shared.RequestFeatures;

public class NotificationTypeParameters : RequestParameters
{
    public string? SearchTerm { get; set; }

    public NotificationTypeParameters()
    {
        OrderBy = "Label";
    }
}