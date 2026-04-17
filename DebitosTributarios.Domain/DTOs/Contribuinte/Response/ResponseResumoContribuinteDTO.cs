namespace DebitosTributarios.Domain.DTOs.Contribuinte.Response
{
    public class ResponseResumoContribuinteDTO(Guid Id, string Nome, int TotalDebitosVencidos, int TotalDebitosEmAberto)
    {
        public Guid Id { get; init; } = Id;
        public string Nome { get; init; } = Nome;
        public int TotalDebitosEmAberto { get; init; } = TotalDebitosEmAberto;
        public int TotalDebitosVencidos { get; init; } = TotalDebitosVencidos;
        public int TotalDebitos { get; private set; } = TotalDebitosEmAberto + TotalDebitosVencidos;
    }
}
