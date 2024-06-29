namespace TestFramework.Support.Fixtures.Dynamic.Models;

public record UserModel {
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Avatar { get; set; }
    public float Balance { get; set; }
    public string PrivacyLevel { get; set; }
    public string Id { get; set; }
    public string Uuid { get; set; }
    public string CreatedAt { get; set; }
    public string ModifiedAt { get; set; }
}
