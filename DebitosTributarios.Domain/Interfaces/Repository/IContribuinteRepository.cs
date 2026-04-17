using DebitosTributarios.Domain.DTOs.Contribuinte.Request;
using DebitosTributarios.Domain.DTOs.Contribuinte.Response;
using DebitosTributarios.Domain.Entities;
using DebitosTributarios.Domain.Interfaces.Repository.Common;

namespace DebitosTributarios.Domain.Interfaces.Repository
{
    public interface IContribuinteRepository : IBaseRepository<Contribuinte>
    {
        Task<bool> CriarAsync(RequestCreateContribuinteDTO content, CancellationToken ct = default);
        Task<bool> CpfCnpjJaCadastrado(string cpfCnpj, CancellationToken ct = default);
        Task<bool> ExistePorIdAsync(Guid id, CancellationToken ct = default);
        Task<ResponseResumoContribuinteDTO?> ObterResumoAsync(Guid id, DateOnly dataReferencia, CancellationToken ct = default);
    }
}
