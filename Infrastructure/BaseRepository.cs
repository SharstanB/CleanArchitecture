using Infrastructure.DataSource;

namespace Infrastructure;

public abstract class BaseRepository
{
    protected CompanyDbContext DbContext { get; set; }

    protected BaseRepository(CompanyDbContext dbContext)
    {
        DbContext = dbContext;
    }
}