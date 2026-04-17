using DebitosTributarios.Domain.Interfaces.Repository.Common;
using DebitosTributarios.Domain.Interfaces.UoW;
using DebitosTributarios.Infrastructure.Context;
using DebitosTributarios.Infrastructure.Repository.Common;
using DebitosTributarios.Infrastructure.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DebitosTributarios.Infrastructure.Extensions
{
    public static class ConfigureInfrastructureExtensions
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            return services.ConfigureRepository(configuration);
        }

        private static IServiceCollection ConfigureRepository(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString =
                Environment.GetEnvironmentVariable("CONTEXT_DATA_SOURCE") ?? configuration.GetConnectionString("CONTEXT_DATA_SOURCE")
                ?? throw new InvalidOperationException("String de conexão ao banco de dados não encontrada.");

            services.AddDbContext<DebitosTributariosContext>(options =>
            {
                options.UseNpgsql(connectionString);
                options.LogTo(Console.WriteLine, LogLevel.Information);
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();

            });

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
