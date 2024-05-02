using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class LateMissType
    {
        [Column("LateMissTypeId")]
        public Guid Id { get; set; }
    
        [Required(ErrorMessage = "Late or Miss Type Label is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Late of Miss Type Label is 60 characters" )]
        [MinLength(2, ErrorMessage = "Minimum length for the Late of Miss Type Label is 2 characters")]
        public string? Label { get; set; }

        public ICollection<LateMiss> LateMisses { get; set; }
        public ICollection<LateMissTypeHistory> LateMissTypeHistories { get; set; }
    }
}