using DebitosTributarios.Domain.DTOs.Contribuinte.Request;
using DebitosTributarios.Domain.Errors.Common;
using OneOf;

namespace DebitosTributarios.Domain.Interfaces.UseCases.Contribuinte.Commands
{
    public interface ICriarContribuinteUseCase
    {
        Task<OneOf<bool, BaseError>> CriarAsync(RequestCreateContribuinteDTO content, CancellationToken ct = default);
    }
}
