using DebitosTributarios.Domain.DTOs.Contribuinte.Response;
using DebitosTributarios.Domain.Errors.Common;
using OneOf;

namespace DebitosTributarios.Domain.Interfaces.UseCases.Contribuinte.Queries
{
    public interface IObterResumoContribuinteUseCase
    {
        Task<OneOf<ResponseResumoContribuinteDTO, BaseError>> ObterResumoAsync(Guid id, CancellationToken ct = default);
    }
}
