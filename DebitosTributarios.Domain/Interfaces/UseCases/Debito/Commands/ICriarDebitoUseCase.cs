using DebitosTributarios.Domain.DTOs.Debito.Request;
using DebitosTributarios.Domain.Errors.Common;
using OneOf;

namespace DebitosTributarios.Domain.Interfaces.UseCases.Debito.Commands
{
    public interface ICriarDebitoUseCase
    {
        Task<OneOf<bool, BaseError>> CreateAsync(RequestCreateDebitoDTO content, CancellationToken ct = default);
    }
}
