using EFCoreInheritance.ContextAccessor;
using EFCoreInheritance.Persistence.TablePerHierarchy;
using EFCoreInheritance.Web.Extensions;
using EFCoreInheritance.Web.Services;
using EFCoreInheritance.Web.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;

services
    .AddScoped<ITablePerHierarchyService, TablePerHierarchyService>()
    .AddScoped<ITablePerTypeService, TablePerTypeService>();

services
    .AddScoped<IContextAccessor<TablePerHierarchyDbContext>, ContextAccessor<TablePerHierarchyDbContext>>();

services.UseDbContext(
    configuration, 
    config =>
    {
        // Use only one!!!

        config.UseTablePerHierarchyDbContext();
        //config.UseTablePerTypeDbContext();
    });

builder.Services.AddControllers();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

