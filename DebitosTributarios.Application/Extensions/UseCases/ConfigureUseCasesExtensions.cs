using DebitosTributarios.Application.UseCases.Contribuinte.Commands;
using DebitosTributarios.Application.UseCases.Contribuinte.Queries;
using DebitosTributarios.Application.UseCases.Debito.Commands;
using DebitosTributarios.Domain.Interfaces.UseCases.Contribuinte.Commands;
using DebitosTributarios.Domain.Interfaces.UseCases.Contribuinte.Queries;
using DebitosTributarios.Domain.Interfaces.UseCases.Debito.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace DebitosTributarios.Application.Extensions.UseCases
{
    public static class ConfigureUseCasesExtensions
    {
        public static IServiceCollection AddApplicationUseCases(this IServiceCollection services)
        {
            services.AddTransient<ICriarContribuinteUseCase, CriarContribuinteUseCase>();

            services.AddTransient<IObterResumoContribuinteUseCase, ObterResumoContribuinteUseCase>();
            services.AddTransient<ICriarDebitoUseCase, CriarDebitoUseCase>();

            return services;
        }
    }
}
