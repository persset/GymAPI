using GymAPI.Models;
using GymAPI.Services.Functionary;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FunctionaryController : ControllerBase {
    private readonly IFunctionaryService functionaryService;
    public FunctionaryController(IFunctionaryService functionaryService) {
        this.functionaryService = functionaryService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Functionary>>> GetAllFunctionaries() {
        return await functionaryService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Functionary>> GetFunctionaryById([FromRoute]int id) {
        var response = await functionaryService.GetById(id);

        if(response is null) return NotFound("Functionary Not Found");

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Functionary>> CreateFunctionary([FromBody]Functionary functionary) {
        var response = await functionaryService.Create(functionary);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Functionary>> UpdateFunctionary([FromRoute]int id, [FromBody]Functionary functionary) {
        var response = await functionaryService.Update(id, functionary);

        if(response is null) return NotFound("Functionary Not Found");

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Functionary>> DeleteFunctionary([FromRoute]int id) {
        var response = await functionaryService.Delete(id);

        if(response is null) return NotFound("Functionary Not Found");

        return Ok(response);
    }
}