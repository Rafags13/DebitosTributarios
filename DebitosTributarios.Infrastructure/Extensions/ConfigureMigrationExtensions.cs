using DebitosTributarios.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DebitosTributarios.Infrastructure.Extensions
{
    public static class ConfigureMigrationExtensions
    {
        public static void ConfigureMigrations(this IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<DebitosTributariosContext>();

            context?.Database.Migrate();
        }
    }
}
