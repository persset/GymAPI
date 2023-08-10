using GymAPI.Models;
using GymAPI.Services.PlanPeriodicity;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlanPeriodicityController : ControllerBase
{
    private readonly IPlanPeriodicityService planPeriodicityService;

    public PlanPeriodicityController(IPlanPeriodicityService planPeriodicityService)
    {
        this.planPeriodicityService = planPeriodicityService;
    }

    [HttpGet]
    public async Task<ActionResult<List<PlanPeriodicity>>> GetAllPlans()
    {
        return await planPeriodicityService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlanPeriodicity>> GetPlan([FromRoute] int id)
    {
        var response = await planPeriodicityService.GetById(id);

        if (response == null) return NotFound("PlanPeriodicity not found");

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<PlanPeriodicity>> CreatePlan([FromBody] PlanPeriodicity planPeriodicity)
    {
        var response = await planPeriodicityService.Create(planPeriodicity);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PlanPeriodicity>> UpdatePlan([FromRoute] int id, [FromBody] PlanPeriodicity planPeriodicity)
    {
        var response = await planPeriodicityService.Update(id, planPeriodicity);

        if (response == null) return NotFound("PlanPeriodicity not found");

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PlanPeriodicity>> DeletePlan([FromRoute] int id)
    {
        var response = await planPeriodicityService.Delete(id);

        if (response == null) return NotFound("PlanPeriodicity not found");

        return Ok(response);
    }
}