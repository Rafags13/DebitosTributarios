using DebitosTributarios.Domain.Errors.Common;
using Microsoft.AspNetCore.Http;

namespace DebitosTributarios.Domain.Errors.Contribuinte
{
    public record CpfCnpjJaCadastradoError() :
        BaseError("Já existe um contribuinte cadastrado com esse CPF/CNPJ", nameof(CpfCnpjJaCadastradoError), StatusCodes.Status400BadRequest);

    public record NomeEhObrigatorioError() :
        BaseError("O nome do contribuinte é obrigatório", nameof(NomeEhObrigatorioError), StatusCodes.Status400BadRequest);

    public record CpfCnpjEhObrigatorioError() :
        BaseError("O CPF/CNPJ do contribuinte é obrigatório", nameof(CpfCnpjEhObrigatorioError), StatusCodes.Status400BadRequest);

    public record ContribuinteNaoExisteError() :
        BaseError("O Contribuinte não foi encontrado.", nameof(ContribuinteNaoExisteError), StatusCodes.Status204NoContent);
}
