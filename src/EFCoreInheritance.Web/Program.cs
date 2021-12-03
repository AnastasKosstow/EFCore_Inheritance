using EFCoreInheritance.Persistence.TablePerHierarchy;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

AddTablePerHierarchyDbContext();

builder.Services.AddControllers();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

void AddTablePerHierarchyDbContext()
{
    builder.Services.AddDbContext<TablePerHierarchyDbContext>(config =>
    {
        config.UseSqlServer(builder.Configuration.GetConnectionString("TPH_Connection"));
    });
}