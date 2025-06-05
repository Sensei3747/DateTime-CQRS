using DateTime.Application.Users.Login;
using DateTime.Application.Users.Register;
using DateTime.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DateTime.Application.Program.AddProgram;
using DateTime.Application.Program.GetPrograms;
using DateTime.Domain.Abstractions;
using DateTime.Application.ProgramRegistration.AddRegistration;

namespace DateTime.API.Controllers.ProgramRegistration;

[Route("api/registration")]
[ApiController]
[AllowAnonymous]
public class RegistrationController : ControllerBase
{
    private readonly ISender _sender;

    public RegistrationController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(AddRegistrationRequest request)
    {
        var command = new AddRegistrationCommand(request.programId, request.UserId, request.location);
        var result = await _sender.Send(command);
        if (result.IsFailure)
        {
            return result.Error.ToActionResult();
        }
        return Ok(result.Value);
    }

}