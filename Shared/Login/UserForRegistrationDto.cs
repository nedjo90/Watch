using System.ComponentModel.DataAnnotations;

namespace Shared.Login;

public record UserForRegistrationDto
{
    [Required(ErrorMessage = "First name is required")]
    public string? FirstName { get; init; }
    [Required(ErrorMessage = "Last name is required")]
    public string? LastName { get; init; }
    
    public string? ProfilPicture { get; init; }
    [Required(ErrorMessage = "Address is required")]
    public string? Address { get; init; }
    [Required(ErrorMessage = "Post Code is required")]
    public string? Postcode { get; init; }
    [Required(ErrorMessage = "City is required")]
    public string? City { get; init; }
    [Required(ErrorMessage = "Country is required")]
    public string? Country { get; init; }
    [Required(ErrorMessage = "Birthday is required")]
    public string? Birthday { get; init; }
    [Required(ErrorMessage = "Native City is required")]
    public string? NativeCity { get; init; }
    [Required(ErrorMessage = "Native Country is required")]
    public string? NativeCountry { get; init; }
    public string? UserName { get; init; }
    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; init; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public Guid? ProfessionalStatusId { get; init; }
    public ICollection<string>? Roles { get; init; }
}