using EFCoreInheritance.Persistence.TablePerHierarchy;
using EFCoreInheritance.Persistence.TablePerType;
using Microsoft.EntityFrameworkCore;

namespace EFCoreInheritance.Web.Extensions.Configurations;

public class DbContextConfiguration : IDbContextConfiguration
{
    private readonly IServiceCollection _services;
    private readonly IConfiguration _configuration;

    public DbContextConfiguration(
        IServiceCollection services,
        IConfiguration configuration)
    {
        _services = services;
        _configuration = configuration;
    }

    public void UseTablePerHierarchyDbContext()
    {
        _services.AddDbContext<TablePerHierarchyDbContext>(config =>
        {
            config.UseSqlServer(_configuration.GetConnectionString("TPH_Connection"));
        });
    }

    public void UseTablePerTypeDbContext()
    {
        _services.AddDbContext<TablePerTypeDbContext>(config =>
        {
            config.UseSqlServer(_configuration.GetConnectionString("TPT_Connection"));
        });
    }
}
