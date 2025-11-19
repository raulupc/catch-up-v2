using pc2u202319415.Subscriptions.Domain.Repositories;
using pc2u202319415.Shared.Domain.Repositories;
using pc2u202319415.Shared.Infrastructure.Persistence.EFC;
using pc2u202319415.Subscriptions.Infrastructure.Persistence.EFC.Repositories;

namespace pc2u202319415.Shared.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Implementación de Unit of Work.
/// </summary>
/// <remarks>Raul Tasayco</remarks>
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private PlanRepository? _planRepository;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IPlanRepository PlanRepository => _planRepository ??= new PlanRepository(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}