using Domain.CoreServices;
using Domain.DataTransferObjects;
using MediatR;

namespace Application.Queries;

public class BranchQueries : IRequest<OperationResult<IEnumerable<BaseBranchDto>>>
{
    
}