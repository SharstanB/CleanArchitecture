using Domain.Basic;

namespace Domain.Models;
public class Product : BaseEntity
{
    public Product()
    {
        BranchProducts = new HashSet<BranchProduct>();
    }
    public string Name { get; set; }

    public string Model { get; set; }

    public double Price { get; set; } // local price
    public ICollection<BranchProduct> BranchProducts { get; set; }
}