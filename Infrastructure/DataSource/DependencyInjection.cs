using Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DataSource;

public static class DependencyInjection
{
    public static IServiceCollection AddDbInfrastracture(this IServiceCollection serviceCollection 
        , IConfiguration configuration)
    {
        serviceCollection.AddDbContext<CompanyDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("LinuxDefaultConnection"));
        });

        serviceCollection.AddScoped<DbContext, CompanyDbContext>();
        serviceCollection.AddTransient<IApplicationDbContext, CompanyDbContext>();

        return serviceCollection;
    }
}