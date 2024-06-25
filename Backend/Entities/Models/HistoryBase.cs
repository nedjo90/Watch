using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public abstract class HistoryBase
{
    [Column(Order = 1)]
    public Guid Id { get; set; }
    [Column(Order = 2)]
    public string ModifierUserId { get; set; }
    public User ModifierUser { get; set; }
    [Column(Order = 3)]
    public string TypeOfModification { get; set; }
    [Column(Order = 4)]
    public DateTime DateOfModification { get; set; } = DateTime.UtcNow;
}