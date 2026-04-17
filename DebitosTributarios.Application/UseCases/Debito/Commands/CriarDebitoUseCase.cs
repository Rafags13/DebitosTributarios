using DebitosTributarios.Domain.DTOs.Debito.Request;
using DebitosTributarios.Domain.Errors.Common;
using DebitosTributarios.Domain.Errors.Contribuinte;
using DebitosTributarios.Domain.Errors.Debito;
using DebitosTributarios.Domain.Interfaces.UoW;
using DebitosTributarios.Domain.Interfaces.UseCases.Debito.Commands;
using OneOf;

namespace DebitosTributarios.Application.UseCases.Debito.Commands
{
    internal sealed class CriarDebitoUseCase(IUnitOfWork unitOfWork) : ICriarDebitoUseCase
    {
        public async Task<OneOf<bool, BaseError>> CreateAsync(RequestCreateDebitoDTO content, CancellationToken ct = default)
        {
            var erro = await ValidateAsync(content, ct);
            if (erro != null) return erro;

            if (!await unitOfWork.DebitoRepository.CriarAsync(content, ct))
                return new DatabaseError();

            return true;
        }

        private async Task<BaseError?> ValidateAsync(RequestCreateDebitoDTO content, CancellationToken ct = default)
        {
            if(content.Valor <= 0)
                return new ValorMenorQueZeroError();

            if (content.DataVencimento == default)
                return new DataVencimentoEhObrigatoria();

            if (!await unitOfWork.ContribuinteRepository.ExistePorIdAsync(content.ContribuinteId, ct))
                return new ContribuinteNaoExisteError();

            return null;
        }
    }
}
