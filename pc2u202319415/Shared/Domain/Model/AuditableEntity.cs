using System.ComponentModel.DataAnnotations;

namespace pc2u202319415.Shared.Domain.Model;

/// <summary>
/// Entidad base auditable con fechas de creación y actualización.
/// </summary>
/// <remarks>Raul Tasayco</remarks>
public abstract class AuditableEntity
{
    [Required]
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;

    [Required]
    public DateTime UpdatedAt { get; protected set; } = DateTime.UtcNow;

    /// <summary>
    /// Actualiza la fecha de actualización (llamable desde repositorios).
    /// </summary>
    public void UpdateUpdatedAt() => UpdatedAt = DateTime.UtcNow;  // <-- Cambiado a public
}