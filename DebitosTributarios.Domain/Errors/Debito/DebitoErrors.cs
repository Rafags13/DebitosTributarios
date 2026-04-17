using DebitosTributarios.Domain.Errors.Common;
using Microsoft.AspNetCore.Http;

namespace DebitosTributarios.Domain.Errors.Debito
{
    public record ValorMenorQueZeroError() :
        BaseError("O valor do débito deve ser maior que zero.", nameof(ValorMenorQueZeroError), StatusCodes.Status400BadRequest);

    public record DataVencimentoEhObrigatoria() :
        BaseError("A data de vencimento é obrigatória.", nameof(ValorMenorQueZeroError), StatusCodes.Status400BadRequest);
}
