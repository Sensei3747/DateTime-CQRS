using DateTime.Application.Participants;
using DateTime.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DateTime.API.Controllers.Participants;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class ParticipantsController : ControllerBase
{
  private readonly ISender _sender;
  public ParticipantsController(ISender sender)
  {
    _sender = sender;
  }

  [HttpPost("Create")]
  public async Task<IActionResult> Create(CreateParticipantRequest request)
  {
    var command = new CreateParticipantCommand(request.name, request.branchId, request.createdByUserId);
    var result = await _sender.Send(command);
    if (result.IsFailure)
    {
      return result.Error.ToActionResult();
    }
    return Ok(result.Value);
  }

  [HttpPost("List")]
  public async Task<IActionResult> List(ListParticipantsRequest request)
  {
    var query = new ListParticipantsQuery(request.branchId);
    var result = await _sender.Send(query);
    if (result.IsFailure)
    {
      return result.Error.ToActionResult();
    }
    return Ok(result.Value);
  }

  [HttpPost("Get")]
  public async Task<IActionResult> Get(GetParticipantRequest request)
  {
    var query = new GetParticipantQuery(request.name);
    var result = await _sender.Send(query);
    if (result.IsFailure)
    {
      return result.Error.ToActionResult();
    }
    return Ok(result.Value);
  }

  [HttpPost("Role")]
  public async Task<IActionResult> Role(string userId)
  {
    var query = new GetParticipantsForUserTypeQuery(userId);
    var result = await _sender.Send(query);
    if (result.IsFailure)
    {
      return result.Error.ToActionResult();
    }
    return Ok(result.Value);
  }
}
