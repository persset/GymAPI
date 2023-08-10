using GymAPI.Models;
using GymAPI.Services.Training;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrainingController : ControllerBase
{
    private readonly ITrainingService trainingService;

    public TrainingController(ITrainingService trainingService)
    {
        this.trainingService = trainingService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Training>>> GetAllTrainings()
    {
        return await trainingService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Training>> GetTrainingById([FromRoute] int id)
    {
        var response = await trainingService.GetById(id);

        if (response == null) return NotFound("Training not found");

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Training>> CreateTraining([FromBody] Training training)
    {
        var response = await trainingService.Create(training);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Training>> UpdateTraining([FromRoute] int id, [FromBody] Training training)
    {
        var response = await trainingService.Update(id, training);

        if (response == null) return NotFound("Training not found");

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Training>> DeleteTraining([FromRoute] int id)
    {
        var response = await trainingService.Delete(id);

        if (response == null) return NotFound("Training not found");

        return Ok(response);
    }
}