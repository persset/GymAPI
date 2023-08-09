using GymAPI.Models;
using GymAPI.Services.MuscleGroup;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MuscleGroupController : ControllerBase
{
    private readonly IMuscleGroupService muscleGroupService;

    public MuscleGroupController(IMuscleGroupService muscleGroupService)
    {
        this.muscleGroupService = muscleGroupService;
    }

    [HttpGet]
    public async Task<ActionResult<List<MuscleGroup>>> GetAllMuscleGroups()
    {
        return await muscleGroupService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MuscleGroup>> GetMuscleGroupById([FromRoute] int id)
    {
        var response = await this.muscleGroupService.GetById(id);

        if (response is null) return NotFound("Muscle group not found");

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<MuscleGroup>> CreateMuscleGroup([FromBody] MuscleGroup muscleGroup)
    {
        var response = await this.muscleGroupService.Create(muscleGroup);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MuscleGroup>> UpdateMuscleGroup([FromRoute] int id, [FromBody] MuscleGroup muscleGroup)
    {
        var response = await this.muscleGroupService.Update(id, muscleGroup);

        if (response is null) return NotFound("Muscle group not found");

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<MuscleGroup>> DeleteMuscleGroup([FromRoute] int id)
    {
        var response = await this.muscleGroupService.Delete(id);

        if (response is null) return NotFound("Muscle group not found");

        return Ok(response);
    }
}