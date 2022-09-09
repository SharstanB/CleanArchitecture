using Domain.CoreServices;
using Domain.DataTransferObjects;

namespace Application.Services;

public interface IBranchService
{
    public Task<OperationResult<IEnumerable<BaseBranchDto>?>> GetAllBranches();

    public OperationResult<Guid> CreateBranch(CreateBranchDto createBranchDto);
}


// public  



 