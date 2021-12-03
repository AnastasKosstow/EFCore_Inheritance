using EFCoreInheritance.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;

services.UseDbContext(
    configuration, 
    config =>
    {
        // Use only one!!!

        //config.UseTablePerHierarchyDbContext();
        config.UseTablePerTypeDbContext();
    });

builder.Services.AddControllers();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

