using DebitosTributarios.Domain.DTOs.Debito.Request;
using System.ComponentModel.DataAnnotations.Schema;

namespace DebitosTributarios.Domain.Entities
{
    public class Debito : EntidadeBase
    {
        public decimal Valor { get; init; }
        public DateTime DataVencimento { get; init; }
        public DateTime? DataPagamento { get; init; }
        public Guid ContribuinteId { get; init; }

        protected Debito() { }

        public Debito(RequestCreateDebitoDTO content)
        {
            ContribuinteId = content.ContribuinteId;
            Valor = content.Valor;
            DataVencimento = content.DataVencimento;
        }

        #region Factory
        public static Debito Criar(RequestCreateDebitoDTO content)
        {
            return new Debito(content);
        }
        #endregion

        #region [Foreign Keys]
        [ForeignKey(nameof(ContribuinteId))]
        public Contribuinte? Contribuinte { get; init; }
        #endregion
    }
}
