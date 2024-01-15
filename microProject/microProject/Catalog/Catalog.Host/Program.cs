using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Mapping;
using Catalog.Host.Repositories;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Catalog.Host.Services.Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;


var configuration = GetConfiguration();

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddTransient<IBrandService, BrandService>();
builder.Services.AddTransient<IBaseRepository<Car>,BaseRepository<Car>>();
builder.Services.AddTransient<IBaseRepository<Brand>,BaseRepository<Brand>>();

builder.Services.AddDbContext<AppDbContext>(opts => opts.UseNpgsql(configuration["ConnectionString"]));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.MapControllers();
//app.UseHttpsRedirection();

CreateDbIfNotExists(app);

app.Run();

IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    return builder.Build();
}

void CreateDbIfNotExists(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<AppDbContext>();

            DbInitializer.Initialize(context).Wait();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred creating the DB.");
        }
    }
}