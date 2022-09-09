using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataSource.EntityConfigurations;

public class CompanyConfigurations : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable(nameof(Company), a => a.IsTemporal());
        builder.HasMany<Branch>().WithOne()
            .HasForeignKey(a => a.CompanyId)
            .IsRequired(false);
    }
}