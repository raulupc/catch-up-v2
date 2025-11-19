using pc2u202319415.Subscriptions.Domain.Repositories;

namespace pc2u202319415.Shared.Domain.Repositories;

/// <summary>
/// Interfaz para Unit of Work.
/// </summary>
/// <remarks>Raul Tasayco</remarks>
public interface IUnitOfWork
{
    IPlanRepository PlanRepository { get; }
    Task<int> SaveChangesAsync();
}