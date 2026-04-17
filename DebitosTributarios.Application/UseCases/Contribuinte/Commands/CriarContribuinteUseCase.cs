using DebitosTributarios.Domain.DTOs.Contribuinte.Request;
using DebitosTributarios.Domain.Errors.Common;
using DebitosTributarios.Domain.Errors.Contribuinte;
using DebitosTributarios.Domain.Helpers;
using DebitosTributarios.Domain.Interfaces.UoW;
using DebitosTributarios.Domain.Interfaces.UseCases.Contribuinte.Commands;
using OneOf;

namespace DebitosTributarios.Application.UseCases.Contribuinte.Commands
{
    public sealed class CriarContribuinteUseCase(IUnitOfWork unitOfWork) : ICriarContribuinteUseCase
    {
        public async Task<OneOf<bool, BaseError>> CriarAsync(RequestCreateContribuinteDTO content, CancellationToken ct = default)
        {
            var erro = await ValidateAsync(content, ct);
            if (erro != null) return erro;

            if (!await unitOfWork.ContribuinteRepository.CriarAsync(content, ct))
                return new DatabaseError();

            return true;
        }

        private async Task<BaseError?> ValidateAsync(RequestCreateContribuinteDTO content, CancellationToken ct = default)
        {
            if (string.IsNullOrEmpty(content.CpfCnpj))
                return new CpfCnpjEhObrigatorioError();

            if(!ValidateCpfCnpjHelper.ValidarCpfCnpj(content.CpfCnpj))
                return new CpfCnpjNaoEhValidoError();

            if (string.IsNullOrEmpty(content.Nome))
                return new NomeEhObrigatorioError();

            if (await unitOfWork.ContribuinteRepository.CpfCnpjJaCadastrado(content.CpfCnpj, ct))
                return new CpfCnpjJaCadastradoError();

            return null;
        }
    }
}
