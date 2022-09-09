namespace Domain.Basic;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    
    public Guid CreatedBy { get; set; }

    public Guid UpdatedBy { get; set; }

    public Guid DeletedBy { get; set; }
}