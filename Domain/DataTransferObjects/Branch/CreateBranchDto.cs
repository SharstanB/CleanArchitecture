using Domain.Models;

namespace Domain.DataTransferObjects;

public class CreateBranchDto : BaseBranchDto
{
    public Guid ParentBranchId { get; set; }


    public Branch ToEntity() => new Branch()
    {
       Name = Name,
       Address = Location,
       CompanyId = CompanyId,
       ParentBranchId = ParentBranchId,
    };
}