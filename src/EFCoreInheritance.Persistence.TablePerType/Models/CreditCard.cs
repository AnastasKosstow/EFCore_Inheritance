namespace EFCoreInheritance.Persistence.TablePerType.Models;

public record CreditCard : BillingDetail
{
    public int CardType { get; set; }
    public string ExpiryMonth { get; set; }
    public string ExpiryYear { get; set; }
}