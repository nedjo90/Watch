using System.ComponentModel.DataAnnotations;

namespace Shared.AttributeFilter;

public class DateValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        string? date = value as string;
        return date != null && DateTime.TryParse(date, out _);
    }
}