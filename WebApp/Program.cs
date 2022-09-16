using Domain.Interfaces;
using Infrastructure.DataSource;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddDbContext<CompanyDbContext>(option =>
// {
//     option.UseSqlServer(builder.Configuration.GetConnectionString("LinuxDefaultConnection"));
// });
// builder.Services.AddHttpClient();

builder.Services.AddDbInfrastracture(builder.Configuration);

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    )
    .AddApplicationPart(typeof(CompanyController).Assembly);

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IBranchRepository, BranchRepository>();

var assembly = AppDomain.CurrentDomain.Load("Application");
builder.Services.AddMediatR(assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

 app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<CompanyDbContext>(); 
        //context.Database.Migrate();
        context.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
    }
}
app.Run();