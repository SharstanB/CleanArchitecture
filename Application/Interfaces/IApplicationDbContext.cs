using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application;

public interface IApplicationDbContext : IDisposable
{ 
    DbSet<Company> Companies { get; set; }
    DbSet<Branch> Branches { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<BranchProduct> BranchProducts { get; set; }
    DbSet<PriceLog> PriceLogs { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}