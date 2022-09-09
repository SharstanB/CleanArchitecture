using Application.ExtentionMethods;
using Domain.CoreServices;
using Domain.DataTransferObjects.Product;
using Domain.Interfaces;

namespace Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<OperationResult<IEnumerable<BaseProductInfo>>> GetAll()
        => (await _productRepository.GetAll()).SuccessResult();
}