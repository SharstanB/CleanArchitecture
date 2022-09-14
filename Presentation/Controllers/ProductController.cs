
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController : ControllerBase
{
     public ProductController()
     {
     }
     // [HttpGet]
     // public async Task<IActionResult>  GetAll()
     //      =>(await _productService.GetAll()).ToJsonResult();
}