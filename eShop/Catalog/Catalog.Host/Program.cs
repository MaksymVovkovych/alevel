using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Mapping;
using Catalog.Host.Repositories;
using Catalog.Host.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var configuration = GetConfiguration();

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddScoped<ICatalogBrandRepository, CatalogBrandRepository>();
builder.Services.AddScoped<ICatalogBffRepository, CatalogBffRepository>();
builder.Services.AddScoped<ICatalogItemRepository, CatalogItemRepository>();
builder.Services.AddScoped<ICatalogTypeRepository, CatalogTypeRepository>();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(configuration["ConnectionString"]));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
// app.UseHttpsRedirection();

CreateDbIfNotExist(app);
app.Run();


IConfiguration GetConfiguration()
{
    var configurationBuilder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
        .AddEnvironmentVariables();
    return configurationBuilder.Build();
}


void CreateDbIfNotExist(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<AppDbContext>();

            DbInitializer.Initialize(context).GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred creating the DB.");
        }
    }
}
