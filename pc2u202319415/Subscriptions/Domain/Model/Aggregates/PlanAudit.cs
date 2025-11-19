using pc2u202319415.Shared.Domain.Model;

namespace pc2u202319415.Subscriptions.Domain.Model.Aggregates;

/// <summary>
/// Entidad para registro de auditoría de Plan (extensible para logs).
/// </summary>
/// <remarks>Raul Tasayco</remarks>
public class PlanAudit : AuditableEntity
{
    public int PlanId { get; private set; }
    public string Action { get; private set; } = string.Empty; // ej. "Created", "Updated"

    private PlanAudit() { }

    public PlanAudit(int planId, string action)
    {
        PlanId = planId;
        Action = action;
    }
}