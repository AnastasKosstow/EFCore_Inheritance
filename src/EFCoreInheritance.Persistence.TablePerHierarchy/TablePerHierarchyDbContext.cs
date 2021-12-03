using EFCoreInheritance.Persistence.TablePerHierarchy.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreInheritance.Persistence.TablePerHierarchy;

public class TablePerHierarchyDbContext : DbContext
{
    public TablePerHierarchyDbContext(DbContextOptions<TablePerHierarchyDbContext> options)
        : base(options)
    {
    }

    public DbSet<Blog>? Blogs { get; set; } = default;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TablePerHierarchyDbContext).Assembly);
    }
}
