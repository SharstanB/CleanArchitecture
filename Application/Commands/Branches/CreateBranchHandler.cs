using Application.ExtentionMethods;
using Domain.CoreServices;
using Domain.DataTransferObjects;
using Domain.Interfaces;
using MediatR;

namespace Application.Commands.Branches;

public class CreateBranchHandler : IRequestHandler<CreateBranchCommand, OperationResult<Guid>>
{
    private readonly IBranchRepository _branchRepository;
    public CreateBranchHandler(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public async Task<OperationResult<Guid>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    =>  _branchRepository.Insert(request.CreateBranchDto).SuccessResult();
    

}