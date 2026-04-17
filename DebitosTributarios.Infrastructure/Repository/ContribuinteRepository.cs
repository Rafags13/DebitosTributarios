using DebitosTributarios.Domain.DTOs.Contribuinte.Request;
using DebitosTributarios.Domain.DTOs.Contribuinte.Response;
using DebitosTributarios.Domain.Entities;
using DebitosTributarios.Domain.Interfaces.Repository;
using DebitosTributarios.Infrastructure.Context;
using DebitosTributarios.Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace DebitosTributarios.Infrastructure.Repository
{
    internal sealed class ContribuinteRepository(DebitosTributariosContext context) : BaseRepository<Contribuinte>(context), IContribuinteRepository
    {
        public Task<bool> CpfCnpjJaCadastrado(string cpfCnpj, CancellationToken ct = default)
        {
            return context.Contribuintes.AnyAsync(x => x.CpfCnpj == cpfCnpj, ct);
        }

        public async Task<bool> CriarAsync(RequestCreateContribuinteDTO content, CancellationToken ct)
        {
            var contribuinte = Contribuinte.CriarContribuinte(content);

            await context.Contribuintes.AddAsync(contribuinte, ct);

            return await context.SaveChangesAsync(ct) > 0;
        }

        public Task<bool> ExistePorIdAsync(Guid id, CancellationToken ct = default)
        {
            return context.Contribuintes.AnyAsync(x => x.Id == id, ct);
        }

        public Task<ResponseResumoContribuinteDTO?> ObterResumoAsync(Guid id, DateOnly dataReferencia, CancellationToken ct = default)
        {
            return context.Contribuintes.Where(x => x.Id == id)
                .Select(Contribuinte.CriarResumo(dataReferencia))
                .FirstOrDefaultAsync(ct);
        }
    }
}
