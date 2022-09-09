using Application.ExtentionMethods;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController : ControllerBase
{
     private readonly IProductService _productService;
     public ProductController(IProductService productService)
     {
          _productService = productService;
     }
     [HttpGet]
     public async Task<IActionResult>  GetAll()
          =>(await _productService.GetAll()).ToJsonResult();
}