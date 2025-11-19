using pc2u202319415.Subscriptions.Domain.Model.Aggregates;
using pc2u202319415.Subscriptions.Interfaces.REST.Resources;

namespace pc2u202319415.Subscriptions.Interfaces.REST.Transform;

/// <summary>
/// Assembler de Entity a Resource.
/// </summary>
/// <remarks>Raul Tasayco</remarks>
public static class PlanAssembler
{
    public static PlanResource ToResourceFromEntity(Plan entity) =>
        new(entity.Id, entity.Name, entity.MaxUsers, entity.MonetizationStrategyId);
}