using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using pc2u202319415.Shared.Domain.Model;
using pc2u202319415.Shared.Domain.Repositories;
using pc2u202319415.Shared.Infrastructure.Persistence.EFC;

namespace pc2u202319415.Shared.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Repositorio base genérico.
/// </summary>
/// <typeparam name="TEntity">Entidad.</typeparam>
/// <remarks>Raul Tasayco</remarks>
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity?> FindByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        if (entity is AuditableEntity auditable) auditable.UpdateUpdatedAt();
        await _context.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        if (entity is AuditableEntity auditable) auditable.UpdateUpdatedAt();
        _context.Set<TEntity>().Update(entity);
        await Task.CompletedTask;
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();
        if (filter != null) query = query.Where(filter);
        return await query.ToListAsync();
    }

    public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();
        if (filter != null) query = query.Where(filter);
        return await query.CountAsync();
    }
}