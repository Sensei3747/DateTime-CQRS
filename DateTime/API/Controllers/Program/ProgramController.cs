
using DateTime.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DateTime.Application.Program.AddProgram;
using DateTime.Application.Program.GetPrograms;


namespace DateTime.API.Controllers.Program;

[Route("api/program")]
[ApiController]
[AllowAnonymous]
public class ProgramController : ControllerBase
{
    private readonly ISender _sender;

    public ProgramController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(AddRequest request)
    {
        var command = new AddProgramCommand(request.name, request.location, request.startTime, request.endTime, request.price, request.limit);
        var result = await _sender.Send(command);
        if (result.IsFailure)
        {
            return result.Error.ToActionResult();
        }
        return Ok(result.Value);
    }

    [HttpPost("get")]
    public async Task<IActionResult> Get(GetRequest request)
    {
        var query = new GetProgramsQuery(request.timezoneId);
        var result = await _sender.Send(query);
        if (result.IsFailure)
        {
            return result.Error.ToActionResult();
        }
        return Ok(result.Value);
    }
}