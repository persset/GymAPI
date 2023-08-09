using GymAPI.Models;
using GymAPI.Services.Exercise;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseService exerciseService;

    public ExerciseController(IExerciseService exerciseService)
    {
        this.exerciseService = exerciseService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Exercise>>> GetAllExercises()
    {
        return await exerciseService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Exercise>> GetExerciseById([FromRoute] int id)
    {
        var response = await exerciseService.GetById(id);

        if (response == null)
            return NotFound("Exercise not found");

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Exercise>> CreateExercise([FromBody] Exercise exercise)
    {
        var response = await exerciseService.Create(exercise);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Exercise>> UpdateExercise([FromRoute] int id, [FromBody] Exercise exercise)
    {
        var response = await exerciseService.Update(id, exercise);

        if (response == null)
            return NotFound("Exercise not found");

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Exercise>> DeleteExercise([FromRoute] int id)
    {
        var response = await exerciseService.Delete(id);

        if (response == null) return NotFound("Exercise not found");

        return Ok(response);
    }
}
