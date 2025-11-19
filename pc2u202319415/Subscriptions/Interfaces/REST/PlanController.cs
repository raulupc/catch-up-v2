using Microsoft.AspNetCore.Mvc;
using pc2u202319415.Subscriptions.Application.Internal.CommandServices;
using pc2u202319415.Subscriptions.Domain.Services;
using pc2u202319415.Subscriptions.Interfaces.REST.Resources;
using pc2u202319415.Subscriptions.Interfaces.REST.Transform;
using pc2u202319415.Shared.Domain.Repositories;
using System.Net.Mime;

namespace pc2u202319415.Subscriptions.Interfaces.REST;

/// <summary>
/// Controlador para Planes.
/// </summary>
/// <remarks>Raul Tasayco</remarks>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PlanController : ControllerBase
{
    private readonly CreatePlanCommandHandler _commandHandler;
    private readonly IPlanDomainService _domainService;

    public PlanController(CreatePlanCommandHandler commandHandler, IPlanDomainService domainService)
    {
        _commandHandler = commandHandler;
        _domainService = domainService;
    }

    /// <summary>
    /// Crea un nuevo Plan.
    /// </summary>
    /// <param name="resource">Datos del plan.</param>
    /// <returns>Plan creado (201).</returns>
    [HttpPost]
    [ProducesResponseType(typeof(PlanResource), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreatePlan([FromBody] CreatePlanResource resource)
    {
        try
        {
            var command = CreatePlanAssembler.ToCommandFromResource(resource);
            var plan = await _commandHandler.HandleAsync(command);
            var response = PlanAssembler.ToResourceFromEntity(plan);
            return CreatedAtAction(nameof(CreatePlan), new { id = response.Id }, response);
        }
        catch (ArgumentException e)
        {
            return BadRequest(new { message = e.Message });
        }
        catch (InvalidOperationException e)
        {
            return Conflict(new { message = e.Message });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, new { message = "Unexpected error." });
        }
    }
}