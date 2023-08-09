using GymAPI.Models;
using GymAPI.Services.Client;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase {
    private readonly IClientService clientService;

    public ClientController(IClientService clientService) {
        this.clientService = clientService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Client>>> GetAllClients() {
        return await clientService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> GetClientById([FromRoute]int id) {
        var result = await clientService.GetById(id);
        if (result is null) return NotFound("Client not found");

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Client>> CreateClient([FromBody]Client client) {
        var result = await clientService.Create(client);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Client>> UpdateClient([FromRoute]int id, [FromBody]Client client) {
        var result = await clientService.Update(id, client);

        if(result is null) return NotFound("Client not found");

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Client>> DeleteClient([FromRoute]int id) {
        var result = await clientService.Delete(id);

        if(result is null) return NotFound("Client not found");

        return Ok(result);
    }
}