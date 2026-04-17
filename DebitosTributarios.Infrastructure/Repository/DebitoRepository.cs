using DebitosTributarios.Domain.DTOs.Debito.Request;
using DebitosTributarios.Domain.Entities;
using DebitosTributarios.Domain.Interfaces.Repository;
using DebitosTributarios.Infrastructure.Context;
using DebitosTributarios.Infrastructure.Repository.Common;

namespace DebitosTributarios.Infrastructure.Repository
{
    internal sealed class DebitoRepository(DebitosTributariosContext context) : BaseRepository<Debito>(context), IDebitoRepository
    {
        public async Task<bool> CriarAsync(RequestCreateDebitoDTO content, CancellationToken ct = default)
        {
            var debito = Debito.Criar(content);

            await context.Debitos.AddAsync(debito, ct);

            return await context.SaveChangesAsync(ct) > 0;
        }
    }
}
