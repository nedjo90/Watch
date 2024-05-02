using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class UserHistory : HistoryBase
{
    //User
    [ForeignKey(nameof(User))]
    public string UserId { get; set; }
    public User User { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProfilPicture { get; set; }
    public string Address { get; set; }
    public string Postcode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Birthday { get; set; }
    public string NativeCity { get; set; }
    public string NativeCountry { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public Guid ProfessionalStatusId { get; set; }
    public virtual string? UserName { get; set; }
    public virtual string? NormalizedUserName { get; set; }
    public virtual string? Email { get; set; }
    public virtual string? NormalizedEmail { get; set; }
    public virtual bool EmailConfirmed { get; set; }
    public virtual string? PasswordHash { get; set; }
    public virtual string? SecurityStamp { get; set; }
    public virtual string? ConcurrencyStamp { get; set; }
    public virtual string? PhoneNumber { get; set; }
    public virtual bool PhoneNumberConfirmed { get; set; }
    public virtual bool TwoFactorEnabled { get; set; }
    public virtual DateTimeOffset? LockoutEnd { get; set; }
    public virtual bool LockoutEnabled { get; set; }
    public virtual int AccessFailedCount { get; set; }
}