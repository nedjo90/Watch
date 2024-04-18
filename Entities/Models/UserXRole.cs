using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class UserXRole : TableBase
{
    [Column("UserXRoleId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "UserId is a required field.")]
    public Guid UserId { get; set; }
    public User? User { get; set; }

    [Required(ErrorMessage = "RoleId is a required field.")]
    public Guid RoleId { get; set; }
    public Role? Role { get; set; }
}