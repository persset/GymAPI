using GymAPI.Models;
using GymAPI.Services.Plan;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlanController : ControllerBase
{
    private readonly IPlanService planService;

    public PlanController(IPlanService planService)
    {
        this.planService = planService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Plan>>> GetAllPlans()
    {
        return await planService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Plan>> GetPlan([FromRoute] int id)
    {
        var response = await planService.GetById(id);

        if (response == null) return NotFound("Plan not found");

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Plan>> CreatePlan([FromBody] Plan plan)
    {
        var response = await planService.Create(plan);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Plan>> UpdatePlan([FromRoute] int id, [FromBody] Plan plan)
    {
        var response = await planService.Update(id, plan);

        if (response == null) return NotFound("Plan not found");

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Plan>> DeletePlan([FromRoute] int id)
    {
        var response = await planService.Delete(id);

        if (response == null) return NotFound("Plan not found");

        return Ok(response);
    }
}