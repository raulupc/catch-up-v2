using System.Linq.Expressions;

namespace pc2u202319415.Shared.Domain.Repositories;

/// <summary>
/// Interfaz base para repositorios genéricos.
/// </summary>
/// <remarks>Raul Tasayco</remarks>
public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity?> FindByIdAsync(int id);
    Task<TEntity> AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null);
}