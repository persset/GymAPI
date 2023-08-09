using GymAPI.Models;
using GymAPI.Services.TrainingOrganizaton;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrainingOrganizationController : ControllerBase
{
    private readonly ITrainingOrganizationService service;

    public TrainingOrganizationController(ITrainingOrganizationService service)
    {
        this.service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<TrainingOrganization>>> GetAllTrainingOrganizations()
    {
        return await service.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TrainingOrganization>> GetTrainingOrganizationById([FromRoute] int id)
    {
        var response = await service.GetById(id);

        if (response == null) return NotFound("Training organization not found");

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<TrainingOrganization>> CreateTrainingOrganization([FromBody] TrainingOrganization trainingOrganization)
    {
        var response = await service.Create(trainingOrganization);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TrainingOrganization>> UpdateTrainingOrganization([FromRoute] int id, [FromBody] TrainingOrganization training)
    {
        var response = await service.Update(id, training);

        if (response == null) return NotFound("Training organization not found");

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<TrainingOrganization>> DeleteTrainingOrganization([FromRoute] int id)
    {
        var response = await service.Delete(id);

        if (response == null) return NotFound("Training organization not found");

        return Ok(response);
    }
}