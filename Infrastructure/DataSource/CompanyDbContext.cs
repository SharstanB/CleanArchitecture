using Domain.Models;
using Infrastructure.DataSource.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataSource;

public class CompanyDbContext : DbContext
{
    public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
        : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }

    public DbSet<Branch> Branches { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<BranchProduct> BranchProducts { get; set; }

    public DbSet<PriceLog> PriceLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(CompanyDbContext).Assembly);

        builder.HasDefaultSchema("Holiar");

        builder.HasDbFunction(typeof(CompanyDbContext)
                .GetMethod(nameof(ActualPrice),
                    new[] { typeof(double) }))
            .HasName("ActualPrice");
    }

    public double ActualPrice(double a)
        => a * PriceLogs.OrderBy(o => o.ChangingDate).LastOrDefault()!.Price;
}