using EFCoreInheritance.Web.Extensions;
using EFCoreInheritance.Web.Services;
using EFCoreInheritance.Web.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;

// To add migration and create database:
// Run for each context:
// -> Add-Migration {migration name} -Context {context name}
// -> Update-Database -Context {context name}

services.UseDbContext(
    configuration, 
    config =>
    {
        config.UseTablePerHierarchyDbContext();
        config.UseTablePerTypeDbContext();
    });

services
    .AddScoped<ITablePerHierarchyService, TablePerHierarchyService>()
    .AddScoped<ITablePerTypeService, TablePerTypeService>();

builder.Services.AddControllers();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
