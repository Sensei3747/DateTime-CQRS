using DateTime.Application.Users.Login;
using DateTime.Application.Users.Register;
using DateTime.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DateTime.API.Controllers.Users;

[Route("api/users")]
[ApiController]
[AllowAnonymous]
public class UserController : ControllerBase
{
    private readonly ISender _sender;

    public UserController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUser request)
    {
        var command = new RegisterUserCommand(request.email, request.UserName, request.password, request.role);
        var result = await _sender.Send(command);
        if (result.IsFailure)
        {
            return result.Error.ToActionResult();
        }
        return Ok(result.Value);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUser request)
    {
        var query = new LoginUserRequest(request.email, request.password);
        var result = await _sender.Send(query);
        if (result.IsFailure)
        {
            result.Error.ToActionResult();
        }
        return Ok(result.Value);
    }
}


