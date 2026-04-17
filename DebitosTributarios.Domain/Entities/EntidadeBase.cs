namespace DebitosTributarios.Domain.Entities
{
    public class EntidadeBase
    {
        public Guid Id { get; init; }
        public DateTime? DataCriacao { get; set; }
    }
}
