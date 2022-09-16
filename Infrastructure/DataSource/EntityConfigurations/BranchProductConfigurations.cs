using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataSource.EntityConfigurations;

public class BranchProductConfigurations : IEntityTypeConfiguration<BranchProduct>
{
    public void Configure(EntityTypeBuilder<BranchProduct> builder)
    {
        builder.ToTable(nameof(BranchProduct), a => a.IsTemporal());
        builder.HasOne(c=>c.SourceBranch)
            .WithMany(c=>c.SourceBranchs)
            .HasForeignKey(a => a.SourceBranchId)
            .IsRequired(false);

        builder.HasOne(a=>a.DestinationBranch).
             WithMany(c=>c.DestinationBranchs)
            .HasForeignKey(a => a.DestinationBranchId)
            .IsRequired(false);

        builder.HasOne<Product>().WithMany()
            .HasForeignKey(a => a.ProductId)
            .IsRequired(false);
    }
}