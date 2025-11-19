using System.ComponentModel.DataAnnotations;

namespace pc2u202319415.Subscriptions.Interfaces.REST.Resources;

/// <summary>
/// Resource para crear Plan (input).
/// </summary>
/// <remarks>Raul Tasayco</remarks>
public record CreatePlanResource
{
    [Required]
    [StringLength(120)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(1, int.MaxValue)]
    public int MaxUsers { get; set; }

    [Required]
    public bool IsDefault { get; set; }

    [Required]
    [Range(1, 4)]
    public int MonetizationStrategyId { get; set; }
}