using Domain.CoreServices;
using Domain.DataTransferObjects;
using MediatR;

namespace Application.Commands.Branches;

public class CreateBranchCommand :  IRequest<OperationResult<Guid>>
{
    public  CreateBranchDto CreateBranchDto { get; set; } 
}