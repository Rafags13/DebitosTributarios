namespace DebitosTributarios.Domain.DTOs.Debito.Request
{
    public record RequestCreateDebitoDTO(Guid ContribuinteId, decimal Valor, DateTime DataVencimento);
}
