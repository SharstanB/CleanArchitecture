using System.Security.Claims;
using Application;
using Domain.Basic;
using Domain.Models;
using Infrastructure.DataSource.EntityConfigurations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataSource;

public class CompanyDbContext : DbContext , IApplicationDbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CompanyDbContext(DbContextOptions<CompanyDbContext> options, IHttpContextAccessor httpContextAccessor)
        : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private string GetUserId =>  _httpContextAccessor.HttpContext!.User!.FindFirst(ClaimTypes.NameIdentifier)!.Value;
    public Guid CurrentUserId => new(GetUserId); //how do any operation on database which catched form header auth token 
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(CompanyDbContext).Assembly);

        builder.HasDefaultSchema("Holiar");

        builder.HasDbFunction(typeof(CompanyDbContext)
                .GetMethod(nameof(ActualPrice),
                    new[] { typeof(double) }))
            .HasName(nameof(ActualPrice));
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case  EntityState.Deleted :
                    entry.Entity.DeletedBy = CurrentUserId;
                    break;
                case EntityState.Added:
                    entry.Entity.CreatedBy = CurrentUserId;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedBy = CurrentUserId;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
    public double ActualPrice(double a)
        => a * PriceLogs.OrderBy(o => o.ChangingDate).LastOrDefault()!.Price;

    public DbSet<Company> Companies { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Product> Products { get; set; }
    
    public DbSet<BranchProduct> BranchProducts { get; set; }
    public DbSet<PriceLog> PriceLogs { get; set; }
}