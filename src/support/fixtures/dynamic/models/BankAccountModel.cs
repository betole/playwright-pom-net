using System.Runtime.CompilerServices;

namespace TestFramework.Support.Fixtures.Dynamic.Models;

public record BankAccountModel {
    public required string BankName {get; set;}
    public required string AccountNumber {get; set;}
    public required string RoutingNumber {get; set;}
    public string? Id {get; set;}
    public string? Uuid {get; set;}
    public string? UserId {get; set;}
    public bool? IsDeleted {get; set;}
    public string? CreatedAt {get; set;}
    public string? ModifiedAt {get; set;}
}
