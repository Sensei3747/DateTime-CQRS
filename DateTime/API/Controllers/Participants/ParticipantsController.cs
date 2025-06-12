using DateTime.Application.Participants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DateTime.API.Controllers.Participants;

[ApiController]
[Route("api/[controller]")]
public class ParticipantsController : ControllerBase {
  private readonly ISender _m;
  public ParticipantsController(ISender m) { _m = m; }

  [HttpPost]
  public async Task<IActionResult> Create(CreateParticipantCommand c) => Ok(await _m.Send(c));
}
