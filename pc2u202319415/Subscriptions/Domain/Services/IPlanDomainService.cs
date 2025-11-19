using pc2u202319415.Subscriptions.Application.Internal.CommandServices;
using pc2u202319415.Subscriptions.Domain.Model.Aggregates;

namespace pc2u202319415.Subscriptions.Domain.Services;

/// <summary>
/// Interfaz para el servicio de dominio de Plan (reglas de negocio).
/// </summary>
/// <remarks>Raul Tasayco</remarks>
public interface IPlanDomainService
{
    /// <summary>
    /// Maneja la creación de un Plan, aplicando reglas de negocio.
    /// </summary>
    /// <param name="command">Comando con datos del Plan.</param>
    /// <returns>La entidad Plan creada.</returns>
    Task<Plan> HandleCreatePlanAsync(CreatePlanCommand command);
}