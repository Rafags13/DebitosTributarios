using DebitosTributarios.Domain.DTOs.Debito.Request;
using DebitosTributarios.Domain.Errors.Common;
using DebitosTributarios.Domain.Interfaces.UseCases.Debito.Commands;
using Microsoft.AspNetCore.Mvc;

namespace DebitosTributarios.WebApi.Endpoints
{
    internal static class DebitoEndpoints
    {
        internal static IEndpointRouteBuilder MapDebitoEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var root = endpoints.MapGroup("/api/debitos")
                .WithTags("Debitos");

            root.MapPost("", async (
                [FromServices] ICriarDebitoUseCase useCase,
                [FromBody] RequestCreateDebitoDTO content,
                CancellationToken ct = default
            ) =>
            {
                var result = await useCase.CreateAsync(content, ct);

                return result.Match(
                    _ => Results.Created(),
                    error => Results.Json(error, statusCode: error.HttpErrorCode)
                );
            })
                .WithDescription("Endpoint responsável por criar um débito vinculado a um contribuinte")
                .Produces<bool>(StatusCodes.Status201Created)
                .Produces<BaseError>(StatusCodes.Status400BadRequest)
                .Produces<BaseError>(StatusCodes.Status500InternalServerError);

            return endpoints;
        }
    }
}
