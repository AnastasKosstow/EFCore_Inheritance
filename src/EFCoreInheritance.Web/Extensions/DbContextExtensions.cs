using EFCoreInheritance.Web.Extensions.Configurations;

namespace EFCoreInheritance.Web.Extensions;

public static class DbContextExtensions
{
    public static IServiceCollection UseDbContext(
        this IServiceCollection services,
        IConfiguration configuration,
        Action<IDbContextConfiguration> configAction)
    {
        var configurator = new DbContextConfiguration(services, configuration);
        configAction?.Invoke(configurator);
        return services;
    }
}
