using pc2u202319415.Subscriptions.Application.Internal.CommandServices;
using pc2u202319415.Subscriptions.Interfaces.REST.Resources;

namespace pc2u202319415.Subscriptions.Interfaces.REST.Transform;

/// <summary>
/// Assembler de Resource a Command.
/// </summary>
/// <remarks>Raul Tasayco</remarks>
public static class CreatePlanAssembler
{
    public static CreatePlanCommand ToCommandFromResource(CreatePlanResource resource) =>
        new(resource.Name, resource.MaxUsers, resource.IsDefault, resource.MonetizationStrategyId);
}