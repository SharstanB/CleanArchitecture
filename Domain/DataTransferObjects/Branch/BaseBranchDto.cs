using MediatR;

namespace Domain.DataTransferObjects;

public class BaseBranchDto : IRequest
{
    public string Name { get; set; }

    public DateTime CreateDate { get; set; }

    public Guid? ParentBranchId { get; set; }
    public Guid CompanyId { get; set; }
    public string Location { get; set; }
}