using Application.ExtentionMethods;
using Domain.CoreServices;
using Domain.DataTransferObjects;
using Domain.Interfaces;

namespace Application.Services;

public class BranchService : IBranchService
{
    private readonly IBranchRepository _branchRepository;

    public BranchService(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }


    public async Task<OperationResult<IEnumerable<BaseBranchDto>?>> GetAllBranches()
    => (await _branchRepository.GetAll()).SuccessResult();
    public OperationResult<Guid>CreateBranch(CreateBranchDto createBranchDto) => 
        _branchRepository.Insert(createBranchDto).SuccessResult();
    
    
}