using pc2u202319415.Subscriptions.Domain.Model.Aggregates;
using pc2u202319415.Shared.Domain.Repositories;

namespace pc2u202319415.Subscriptions.Domain.Repositories;

/// <summary>
/// Repositorio para Plan.
/// </summary>
/// <remarks>Raul Tasayco</remarks>
public interface IPlanRepository : IBaseRepository<Plan>
{
    Task<bool> ExistsByNameAsync(string name);
    Task<bool> ExistsDefaultPlanAsync();
}