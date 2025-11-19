using pc2u202319415.Shared.Domain.Model;
using pc2u202319415.Subscriptions.Domain.Model.Enumerations;

namespace pc2u202319415.Subscriptions.Domain.Model.Aggregates;

/// <summary>
/// Aggregate Root para Plan.
/// </summary>
/// <remarks>Raul Tasayco</remarks>
public class Plan : AuditableEntity
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public int MaxUsers { get; private set; }
    public bool IsDefault { get; private set; }
    public int MonetizationStrategyId { get; private set; }

    private Plan() { } // Para EF

    public Plan(string name, int maxUsers, bool isDefault, EMonetizationStrategy monetizationStrategy)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        if (name.Length > 120) throw new ArgumentException("Name must be max 120 chars");
        if (maxUsers <= 0) throw new ArgumentException("MaxUsers must be > 0");
        IsDefault = isDefault;
        MonetizationStrategyId = (int)monetizationStrategy;
    }
}