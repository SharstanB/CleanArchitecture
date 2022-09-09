using Infrastructure.DataSource;

namespace Infrastructure;

public class BaseRepository
{
    protected CompanyDbContext DbContext { get; set; }

    public BaseRepository(CompanyDbContext dbContext)
    {
        DbContext = dbContext;
    }
}