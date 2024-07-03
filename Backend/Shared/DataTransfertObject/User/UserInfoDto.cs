namespace Shared.DataTransfertObject.User;

public record UserInfoDto
{
    public string? Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ProfilPicture { get; set; }
    public string? Address { get; set; }
    public string? Postcode { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Birthday { get; set; }
    public IList<string> Roles { get; set; }
    public string? ProfessionalStatus { get; set; }
}