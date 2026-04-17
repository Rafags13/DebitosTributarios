using DebitosTributarios.Domain.Interfaces.Repository;
using DebitosTributarios.Domain.Interfaces.UoW;
using DebitosTributarios.Infrastructure.Context;
using DebitosTributarios.Infrastructure.Repository;

namespace DebitosTributarios.Infrastructure.UoW
{
    internal sealed class UnitOfWork(DebitosTributariosContext context) : IUnitOfWork, IDisposable
    {
        public IContribuinteRepository ContribuinteRepository { get; private set; } = new ContribuinteRepository(context);

        public IDebitoRepository DebitoRepository { get; private set; } = new DebitoRepository(context);

        public Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
