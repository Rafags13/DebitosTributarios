using DebitosTributarios.Domain.Interfaces.Repository;

namespace DebitosTributarios.Domain.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        IContribuinteRepository ContribuinteRepository { get; }
        IDebitoRepository DebitoRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
