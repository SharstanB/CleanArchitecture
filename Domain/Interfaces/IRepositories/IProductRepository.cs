using Domain.CoreServices;
using Domain.DataTransferObjects.Product;

namespace Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<BaseProductInfo>> GetAll();
}