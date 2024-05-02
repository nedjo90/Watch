using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class LateMissStatus : BasicGenericEntity
{
    public ICollection<LateMiss> LateMisses { get; set; }
    public ICollection<LateMissStatusHistory> LateMissStatusHistories { get; set; }
}