using pc2u202319415.Subscriptions.Application.Internal.CommandServices;
using pc2u202319415.Subscriptions.Domain.Model.Aggregates;
using pc2u202319415.Subscriptions.Domain.Model.Enumerations;
using pc2u202319415.Subscriptions.Domain.Repositories;
using pc2u202319415.Subscriptions.Domain.Services;

namespace pc2u202319415.Subscriptions.Domain.Services;

/// <summary>
/// Implementación de servicio de dominio para Plan.
/// </summary>
/// <remarks>Raul Tasayco</remarks>
public class PlanDomainService : IPlanDomainService
{
    private readonly IPlanRepository _repository;

    public PlanDomainService(IPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Plan> HandleCreatePlanAsync(CreatePlanCommand command)
    {
        // Regla: No duplicado name
        if (await _repository.ExistsByNameAsync(command.Name))
            throw new InvalidOperationException("Plan name already exists");

        // Regla: Solo un default
        if (command.IsDefault && await _repository.ExistsDefaultPlanAsync())
            throw new InvalidOperationException("Only one default plan allowed");

        // Regla: monetizationStrategyId válido (1-4)
        if (command.MonetizationStrategyId < 1 || command.MonetizationStrategyId > 4)
            throw new ArgumentException("Invalid MonetizationStrategyId. Must be 1-4.");

        // Regla: maxUsers > 0 (se valida en ctor de Plan, pero revalida aquí)
        if (command.MaxUsers <= 0)
            throw new ArgumentException("MaxUsers must be greater than 0");

        return new Plan(command.Name, command.MaxUsers, command.IsDefault, (EMonetizationStrategy)command.MonetizationStrategyId);
    }
}