namespace EFCoreInheritance.Persistence.TablePerType.Models;

public abstract record BillingDetail
{
    public int Id { get; set; }
    public string Owner { get; set; }
    public string Number { get; set; }
}
