using Domain.Basic;

namespace Domain.Models;

public class Company : BaseEntity
{
    public Company()
    {
        Branches = new HashSet<Branch>();
    }

    public string Name { get; set; }
    public string Address { get; set; }

    public ICollection<Branch> Branches { get; set; }
}
