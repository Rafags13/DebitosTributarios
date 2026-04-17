using DebitosTributarios.Domain.DTOs.Contribuinte.Response;
using DebitosTributarios.Domain.Errors.Common;
using DebitosTributarios.Domain.Errors.Contribuinte;
using DebitosTributarios.Domain.Interfaces.UoW;
using DebitosTributarios.Domain.Interfaces.UseCases.Contribuinte.Queries;
using OneOf;

namespace DebitosTributarios.Application.UseCases.Contribuinte.Queries
{
    internal sealed class ObterResumoContribuinteUseCase(
        IUnitOfWork unitOfWork
    ) : IObterResumoContribuinteUseCase
    {
        public async Task<OneOf<ResponseResumoContribuinteDTO, BaseError>> ObterResumoAsync(Guid id, CancellationToken ct = default)
        {
            var dataAtual = DateOnly.FromDateTime(DateTime.UtcNow);

            var resumo = await unitOfWork.ContribuinteRepository.ObterResumoAsync(id, dataAtual, ct);

            if (resumo is null)
                return new ContribuinteNaoExisteError();

            return resumo;
        }
    }
}
