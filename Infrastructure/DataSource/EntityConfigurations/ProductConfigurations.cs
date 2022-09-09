using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataSource.EntityConfigurations;

public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product), product => product.IsTemporal());

        builder.HasMany<BranchProduct>().WithOne()
            .HasForeignKey(a => a.ProductId)
            .IsRequired(false);
    }
}