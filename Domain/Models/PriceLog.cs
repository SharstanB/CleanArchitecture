using Domain.Basic;

namespace Domain.Models;

public class PriceLog : BaseEntity
{
    public double Price { get; set; }

    public DateTime ChangingDate { get; set; }
}