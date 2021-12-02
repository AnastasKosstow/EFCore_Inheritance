using EFCoreInheritance.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EFCoreInheritanceDbContext>(config =>
{
    config.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection"));
});

builder.Services.AddControllers();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
