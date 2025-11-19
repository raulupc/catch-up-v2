using Microsoft.EntityFrameworkCore;
using pc2u202319415.Subscriptions.Domain.Model.Aggregates;
using pc2u202319415.Subscriptions.Domain.Repositories;
using pc2u202319415.Shared.Infrastructure.Persistence.EFC;
using pc2u202319415.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace pc2u202319415.Subscriptions.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Implementación de repositorio para Plan.
/// </summary>
/// <remarks>Raul Tasayco</remarks>
public class PlanRepository : BaseRepository<Plan>, IPlanRepository
{
    public PlanRepository(AppDbContext context) : base(context) { }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await CountAsync(p => p.Name == name) > 0;
    }

    public async Task<bool> ExistsDefaultPlanAsync()
    {
        return await CountAsync(p => p.IsDefault) > 0;
    }
}