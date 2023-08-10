using GymAPI.Models;
using GymAPI.Services.UserType;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserTypeController : ControllerBase
{
    private readonly IUserTypeService userTypeService;

    public UserTypeController(IUserTypeService userTypeService)
    {
        this.userTypeService = userTypeService;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserType>>> GetAllUserTypes()
    {
        return await userTypeService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserType>> GetUserTypeById([FromRoute] int id)
    {
        var response = await userTypeService.GetById(id);

        if (response == null) return NotFound("User type not found");

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<UserType>> CreateUserType([FromBody] UserType userType)
    {
        var response = await userTypeService.Create(userType);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserType>> UpdateUserType([FromRoute] int id, [FromBody] UserType userType)
    {
        var response = await userTypeService.Update(id, userType);

        if (response == null) return NotFound("User type not found");

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<UserType>> DeleteUserType([FromRoute] int id)
    {
        var response = await userTypeService.Delete(id);

        if (response == null) return NotFound("User type not found");

        return Ok(response);
    }
}