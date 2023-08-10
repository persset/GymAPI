using GymAPI.Models;
using GymAPI.Services.UserPrivilege;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserPrivilegeController : ControllerBase
{
    private readonly IUserPrivilegeService userPrivilegeService;

    public UserPrivilegeController(IUserPrivilegeService userPrivilegeService)
    {
        this.userPrivilegeService = userPrivilegeService;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserPrivilege>>> GetAllUserPrivileges()
    {
        return await userPrivilegeService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserPrivilege>> GetUserPrivilegeById([FromRoute] int id)
    {
        var response = await userPrivilegeService.GetById(id);

        if (response == null) return NotFound("User privilege not found");

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<UserPrivilege>> CreateUserPrivilege([FromBody] UserPrivilege userPrivilege)
    {
        var response = await userPrivilegeService.Create(userPrivilege);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserPrivilege>> UpdateUserPrivilege([FromRoute] int id, [FromBody] UserPrivilege privilege)
    {
        var response = await userPrivilegeService.Update(id, privilege);

        if (response == null) return NotFound("User privilege not found");

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<UserPrivilege>> DeleteUserPrivilege([FromRoute] int id)
    {
        var response = await userPrivilegeService.Delete(id);

        if (response == null) return NotFound("User privilege not found");

        return Ok(response);
    }
}