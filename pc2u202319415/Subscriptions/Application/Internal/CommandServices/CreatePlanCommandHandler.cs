using pc2u202319415.Shared.Domain.Repositories;
using pc2u202319415.Subscriptions.Domain.Services;
using pc2u202319415.Subscriptions.Domain.Model.Aggregates;
using pc2u202319415.Subscriptions.Domain.Repositories;

namespace pc2u202319415.Subscriptions.Application.Internal.CommandServices;

/// <summary>
/// Handler manual para CreatePlanCommand.
/// </summary>
/// <remarks>Raul Tasayco</remarks>
public class CreatePlanCommandHandler
{
    private readonly IPlanDomainService _domainService;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePlanCommandHandler(IPlanDomainService domainService, IUnitOfWork unitOfWork)
    {
        _domainService = domainService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Plan> HandleAsync(CreatePlanCommand command)
    {
        var plan = await _domainService.HandleCreatePlanAsync(command);
        await _unitOfWork.SaveChangesAsync();
        return plan;
    }
}