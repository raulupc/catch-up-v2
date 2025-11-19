using pc2u202319415.Subscriptions.Domain.Model.Enumerations;

namespace pc2u202319415.Subscriptions.Application.Internal.CommandServices;

/// <summary>
/// Comando para crear un Plan.
/// </summary>
/// <remarks>Raul Tasayco</remarks>
public record CreatePlanCommand(string Name, int MaxUsers, bool IsDefault, int MonetizationStrategyId);