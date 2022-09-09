using Domain.CoreServices;
using Domain.DataTransferObjects.Product;
using Domain.Interfaces;
using Infrastructure.DataSource;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepository : BaseRepository, IProductRepository
{
    public ProductRepository(CompanyDbContext dbContext) 
        : base(dbContext)
    {
        
    }

    public async Task<IEnumerable<BaseProductInfo>> GetAll()
        => await DbContext.Products.Select(product => new BaseProductInfo()
        {
         Name = product.Name,
         Model = product.Model,
         Price = DbContext.ActualPrice(product.Price),
        }).ToListAsync();
}