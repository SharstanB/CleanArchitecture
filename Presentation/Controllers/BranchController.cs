using Application.ExtentionMethods;
using Domain.DataTransferObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BranchController : Controller
{

    private readonly IMediator _mediator;
    public BranchController( IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // [HttpGet]
    // public async Task<IActionResult> GetAll()
    //     => (await _branchService.GetAllBranches()).ToJsonResult();

    [HttpGet]
    public async Task<IActionResult> GetAllBranches()
        => _mediator.Send(new BaseBranchDto()).ToJsonResult();
    
    [HttpGet]
    public IActionResult GetById(int id)
    {
        return Json("");
    }
    [HttpPost]
    public  IActionResult CreateBranch(CreateBranchDto createBranch)
        => _mediator.Send(createBranch).ToJsonResult();
}