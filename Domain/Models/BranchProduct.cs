using Domain.Basic;

namespace Domain.Models;
public class BranchProduct : BaseEntity
{
    public Branch SourceBranch { get; set; }

    public Guid SourceBranchId { get; set; }
    
    public Branch DestinationBranch { get; set; }

    public Guid DestinationBranchId { get; set; }

    public Product Product { get; set; }

    public Guid ProductId { get; set; }

    public double Quantity { get; set; }

}