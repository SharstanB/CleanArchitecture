using Application;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DataSource;

public static class DbServiceCollectionExtensions
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
         serviceCollection.AddTransient<IUserResolverService, UserResolverService>();
         serviceCollection.AddHttpContextAccessor();

        return serviceCollection;
    }
}