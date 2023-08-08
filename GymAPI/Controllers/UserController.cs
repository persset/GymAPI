using GymAPI.Models;
using GymAPI.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController: ControllerBase {
    private readonly IUserService userService;

    public UserController(IUserService userService) {
        this.userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUsers() {
        return await userService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById([FromRoute]int id) {
        var result = await userService.GetById(id);
        if (result is null) return NotFound("User Not Found");

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser([FromBody]User user) {
        var result = await userService.Create(user);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<User>> UpdateUser([FromRoute]int id, [FromBody]User user) {
        var result = await userService.Update(id, user);

        if(result is null) return NotFound("User Not Found");

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<User>> DeleteUser([FromRoute]int id) {
        var result = await userService.Delete(id);

        if(result is null) return NotFound("User Not Found");

        return Ok(result);
    }
}