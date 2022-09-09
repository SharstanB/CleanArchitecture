using Domain.Models;

namespace Domain.DataTransferObjects;

public class UpdateBranchDto : BaseBranchDto
{
  public  Guid Id { get; set; }

  public Guid ParentBranchId { get; set; }

  public Branch ToEntity() => new Branch()
  {
    Id = Id,
    Name = Name,
    Address = Location,
    CompanyId = CompanyId,
    ParentBranchId = ParentBranchId,
  };

}