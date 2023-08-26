using Microsoft.AspNetCore.Mvc;

public class AuthController : ControllerBase
{

    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost(Routes.Auth.Register)]
    public async Task<ActionResult<User>> Register(UserRegisterRequest request)
    {
        if (request.Username == null || request.Password == null)
            return BadRequest();
        User? user = await _userService.Get(request.Username);
        if (user != null)
            return Conflict();
        user = await _userService.Create(request.Username, request.Password);
        return CreatedAtAction(nameof(Login), new { username = user.Username }, user);
    }

    [HttpPost(Routes.Auth.Login)]
    public async Task<ActionResult<User>> Login(UserLoginRequest request)
    {
        if (request.Username == null || request.Password == null)
            return BadRequest();
        User? user = await _userService.Get(request.Username);
        if (user == null)
            return NotFound();
        if (user.Password != request.Password)
            return Unauthorized();
        return Ok(user);
    }


}
