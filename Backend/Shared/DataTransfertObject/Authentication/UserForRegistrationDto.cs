using System.ComponentModel.DataAnnotations;
using Shared.AttributeFilter;

namespace Shared.DataTransfertObject.Authentication;

public record UserForRegistrationDto
{
    [Required(ErrorMessage = "First name is required")]
    public string? FirstName { get; init; }

    [Required(ErrorMessage = "Last name is required")]
    public string? LastName { get; init; }

    [Required(ErrorMessage = "Username is required")]
    public string? UserName { get; init; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; init; }

    [Required(ErrorMessage = "Password is required")]
    [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
    public string? ConfirmPassword { get; init; }

    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; init; }

    [Required(ErrorMessage = "Email is required")]
    [Compare(nameof(Email), ErrorMessage = "The email and confirmation Email do not match.")]
    public string? ConfirmEmail { get; init; }

    [Required(ErrorMessage = "Phone number is required")]
    public string? PhoneNumber { get; init; }

    public string ProfilPicture { get; init; } = "none.png";

    [Required(ErrorMessage = "Address is required")]
    public string? Address { get; init; }

    [Required(ErrorMessage = "Post Code is required")]
    public string? Postcode { get; init; }

    [Required(ErrorMessage = "City is required")]
    public string? City { get; init; }

    [Required(ErrorMessage = "Country is required")]
    public string Country { get; init; } = "France";

    [Required(ErrorMessage = "Birthday is required")]
    [DateValidation(ErrorMessage = "Please enter a valid date")]
    public string? Birthday { get; init; }

    [Required(ErrorMessage = "Native City is required")]
    public string NativeCity { get; init; } = "undefined";

    [Required(ErrorMessage = "Native Country is required")]
    public string NativeCountry { get; init; } = "undefined";

    [Required] public Guid ProfessionalStatusId { get; init; }

    [Required(ErrorMessage = "Roles is required")]
    public ICollection<string>? Roles { get; init; } = new List<string> { "Candidate" };
}