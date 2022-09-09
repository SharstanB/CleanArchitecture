using Microsoft.AspNetCore.Mvc;
namespace Presentation.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CompanyController : Controller
{

    public CompanyController()
    {
        
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Json("");
    }
}