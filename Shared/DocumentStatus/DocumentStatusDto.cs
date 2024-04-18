using System.ComponentModel.DataAnnotations;

namespace Shared.DocumentStatus;

public record DocumentStatusDto : DocumentStatusForManipulation
{
    public Guid Id { get; init; }
}