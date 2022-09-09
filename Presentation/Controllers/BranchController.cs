using Application.ExtentionMethods;
using Application.Services;
using Domain.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BranchController : Controller
{

    private readonly IBranchService _branchService;
    public BranchController(IBranchService branchService)
    {
        _branchService = branchService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => (await _branchService.GetAllBranches()).ToJsonResult();
    [HttpGet]
    public IActionResult GetById(int id)
    {
        return Json("");
    }
    [HttpPost]
    public  IActionResult CreateBranch(CreateBranchDto createBranch)
        => _branchService.CreateBranch(createBranch).ToJsonResult();
}