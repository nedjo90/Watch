using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class LateMissStatus : BasicEntity
{
    public ICollection<LateMissXLateMissStatus?>? LateMissXLateMissStatusCollection { get; set; }
}