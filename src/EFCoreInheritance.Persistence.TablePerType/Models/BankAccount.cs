namespace EFCoreInheritance.Persistence.TablePerType.Models;

public record BankAccount : BillingDetail
{
    public string BankName { get; set; }
    public string Swift { get; set; }
}