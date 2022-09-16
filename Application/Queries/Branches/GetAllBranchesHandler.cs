using Application.ExtentionMethods;
using Application.Queries;
using Domain.CoreServices;
using Domain.DataTransferObjects;
using Domain.Interfaces;
using MediatR;

namespace Application;

public class GetAllBranchesHandler : IRequestHandler<BranchQueries ,OperationResult<IEnumerable<BaseBranchDto>>>
{
    private readonly IBranchRepository _branchRepository;
    public GetAllBranchesHandler(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public async Task<OperationResult<IEnumerable<BaseBranchDto>?>> Handle(BranchQueries request, CancellationToken cancellationToken)
        => (await _branchRepository.GetAll()).SuccessResult();
}