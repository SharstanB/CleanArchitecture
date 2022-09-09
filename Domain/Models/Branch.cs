using Domain.Basic;

namespace Domain.Models;

public class Branch : BaseEntity
{
    public Branch()
    {
        SourceBranchs = new HashSet<BranchProduct>();
        DestinationBranchs = new HashSet<BranchProduct>();
        SubBranches = new List<Branch>();
    }
    public string Name { get; set; }
    public string Address { get; set; }
    
    public Company Company { get; set; }
    public Guid CompanyId { get; set; }
    
    public Branch ParentBranch { get; set; }
    public Guid? ParentBranchId { get; set; }
    
    public DateTime CreateDate { get; set; }
    public ICollection<Branch> SubBranches { get; set; }
    public ICollection<BranchProduct> SourceBranchs { get; set; }
    public ICollection<BranchProduct> DestinationBranchs { get; set; }
}