using Domain.CoreServices;
using Domain.DataTransferObjects.Product;

namespace Application.Services;

public interface IProductService
{
    Task<OperationResult<IEnumerable<BaseProductInfo>>> GetAll();
}