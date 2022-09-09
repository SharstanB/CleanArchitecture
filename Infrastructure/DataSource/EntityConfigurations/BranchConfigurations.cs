using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataSource.EntityConfigurations;

public class BranchConfigurations : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.HasOne<Company>()
            .WithMany()
            .HasForeignKey(key => key.CompanyId);

        builder.HasOne(c=>c.ParentBranch)
            .WithMany(c=>c.SubBranches)
            .HasForeignKey(a => a.ParentBranchId)
            // .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.ToTable(nameof(Branch), a => a.IsTemporal());
    }
}