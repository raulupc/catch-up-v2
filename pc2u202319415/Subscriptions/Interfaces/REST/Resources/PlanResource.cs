namespace pc2u202319415.Subscriptions.Interfaces.REST.Resources;

/// <summary>
/// Resource para Plan (output, sin IsDefault).
/// </summary>
/// <remarks>Raul Tasayco</remarks>
public record PlanResource(int Id, string Name, int MaxUsers, int MonetizationStrategyId);