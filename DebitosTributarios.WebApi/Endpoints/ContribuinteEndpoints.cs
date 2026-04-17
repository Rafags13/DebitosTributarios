using DebitosTributarios.Domain.DTOs.Contribuinte.Request;
using DebitosTributarios.Domain.DTOs.Contribuinte.Response;
using DebitosTributarios.Domain.Errors.Common;
using DebitosTributarios.Domain.Interfaces.UseCases.Contribuinte.Commands;
using DebitosTributarios.Domain.Interfaces.UseCases.Contribuinte.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DebitosTributarios.WebApi.Endpoints
{
    internal static class ContribuinteEndpoints
    {
        public static IEndpointRouteBuilder MapContribuinteEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var root = endpoints.MapGroup("/api/contribuintes")
                .WithTags("Contribuintes");

            root.MapPost("", async (
                [FromServices] ICriarContribuinteUseCase useCase,
                [FromBody] RequestCreateContribuinteDTO content,
                CancellationToken ct = default
            ) =>
            {
                var result = await useCase.CriarAsync(content, ct);

                return result.Match(
                    _ => Results.Created(),
                    error => Results.Json(error, statusCode: error.HttpErrorCode)
                );
            })
                .WithDescription("Endpoint responsável por criar um contribuinte no sistema.")
                .Produces<bool>(StatusCodes.Status201Created)
                .Produces<BaseError>(StatusCodes.Status400BadRequest)
                .Produces<BaseError>(StatusCodes.Status500InternalServerError);

            root.MapGet("{id:guid}", async (
                [FromServices] IObterResumoContribuinteUseCase useCase,
                Guid id,
                CancellationToken ct = default) =>
            {
                var result = await useCase.ObterResumoAsync(id, ct);

                return result.Match(
                    success => Results.Ok(success),
                    error => Results.Json(error, statusCode: error.HttpErrorCode)
                );
            })
                .WithDescription("Endpoint responsável por retornar o resumo do contribuinte, com informações de seus débitos.")
                .Produces<ResponseResumoContribuinteDTO>(StatusCodes.Status200OK)
                .Produces<BaseError>(StatusCodes.Status204NoContent)
                .Produces<BaseError>(StatusCodes.Status500InternalServerError);

            return endpoints;
        }
    }
}
