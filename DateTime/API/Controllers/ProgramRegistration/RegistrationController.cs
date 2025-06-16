using DateTime.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using DateTime.Application.ProgramRegistration.AddRegistration;
using DateTime.Application.ProgramRegistration;

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
        var command = new AddRegistrationCommand(request.programId, request.UserId, request.location, request.branchId);
        var result = await _sender.Send(command);
        if (result.IsFailure)
        {
            return result.Error.ToActionResult();
        }
        return Ok(result.Value);
    }

    [HttpPost("Get")]
    public async Task<IActionResult> Get(string userId)
    {
        var query = new GetRegistrationsForUserTypeQuery(userId);
        var result = await _sender.Send(query);
        if (result.IsFailure)
        {
            return result.Error.ToActionResult();
        }
        return Ok(result.Value);
    }

}