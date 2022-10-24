using Ordering.Domain.Common;
using System.Linq.Expressions;

namespace Ordering.Application.Contracts
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        Task<IReadOnlyList<T>> GetAsync(int offset, int limit, Expression<Func<T, bool>> predicate, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, params string[] includeStrings);

        Task<T> AddAsync(T entity);

        Task DeleteAsync(T entity);

        Task<T> GetByIdAsync(int id);

        Task<T> UpdateAsync(T entity);
    }
}

        /*
         Agregar
         borrar
         Obtener todos
         Obtener todos con un filtro
         Obtener todos con un filtro y paginacion
         Obtener uno con un filtro
         Obtener por id
         Actualizar
         */