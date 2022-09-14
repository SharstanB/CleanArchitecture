using Domain.Models;
using MediatR;

namespace Application.Handlers;

public class CompanyHandler 
{
    public Task<Unit> Handle(Company request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}