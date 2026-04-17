using DebitosTributarios.Domain.DTOs.Contribuinte.Request;
using DebitosTributarios.Domain.DTOs.Contribuinte.Response;
using System.Linq.Expressions;

namespace DebitosTributarios.Domain.Entities
{
    public class Contribuinte : EntidadeBase
    {
        public string Nome { get; init; } = string.Empty;
        public string CpfCnpj { get; init; } = string.Empty;

        protected Contribuinte() { }

        public Contribuinte(RequestCreateContribuinteDTO content)
        {
            Nome = content.Nome;
            CpfCnpj = content.CpfCnpj;
        }

        #region [Factory]
        public static Contribuinte CriarContribuinte(RequestCreateContribuinteDTO content)
        {
            return new Contribuinte(content);
        }

        public static Expression<Func<Contribuinte, ResponseResumoContribuinteDTO>> CriarResumo(DateOnly dataReferencia)
        {
            return x => new ResponseResumoContribuinteDTO(
                x.Id,
                x.Nome,
                x.Debitos.Count(d => DateOnly.FromDateTime(d.DataVencimento.Date) > dataReferencia),
                x.Debitos.Count(d => DateOnly.FromDateTime(d.DataVencimento) <= dataReferencia)
            );
        }
        #endregion

        #region Navigations
        public ICollection<Debito> Debitos { get; private set; } = [];
        #endregion
    }
}
