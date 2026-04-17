using DebitosTributarios.Domain.DTOs.Contribuinte.Response;
using DebitosTributarios.Domain.DTOs.Debito.Request;
using DebitosTributarios.Domain.Entities;
using DebitosTributarios.Domain.Interfaces.Repository.Common;

namespace DebitosTributarios.Domain.Interfaces.Repository
{
    public interface IDebitoRepository : IBaseRepository<Debito>
    {
        Task<bool> CriarAsync(RequestCreateDebitoDTO content, CancellationToken ct = default);
    }
}
