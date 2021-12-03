using EFCoreInheritance.Persistence.TablePerType.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreInheritance.Persistence.TablePerType.EntityTypeConfigurations;

internal class BlogEntityTypeConfiguration : IEntityTypeConfiguration<BillingDetail>
{
    public void Configure(EntityTypeBuilder<BillingDetail> builder)
    {
        builder
            .HasKey(blog => blog.Id);
    }
}
