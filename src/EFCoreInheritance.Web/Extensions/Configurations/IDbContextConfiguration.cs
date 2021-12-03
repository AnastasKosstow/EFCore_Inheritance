namespace EFCoreInheritance.Web.Extensions.Configurations;

public interface IDbContextConfiguration
{
    void UseTablePerHierarchyDbContext();
    void UseTablePerTypeDbContext();
}
