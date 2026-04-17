using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DebitosTributarios.Domain.Interfaces.Repository.Common
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);
    }
}
