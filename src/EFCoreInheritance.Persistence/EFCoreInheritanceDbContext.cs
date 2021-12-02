using EFCoreInheritance.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreInheritance.Persistence
{
    public class EFCoreInheritanceDbContext : DbContext
    {
        public EFCoreInheritanceDbContext(DbContextOptions<EFCoreInheritanceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Blog>? Blogs { get; set; } = default;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFCoreInheritanceDbContext).Assembly);
        }
    }
}
