using DateTime.Application.Abstractions.Messaging;
using DateTime.Application.Abstractions.Services;
using DateTime.Domain.Abstractions;
using DateTime.Domain.Participants;
using DateTime.Infrastructure.Data;


namespace DateTime.Application.Participants;

public class CreateParticipantHandler: ICommandHandler<CreateParticipantCommand, Guid> 
{
  private readonly ApplicationDbContext _ctx;
  private readonly IPermissionChecker _pc;

  public CreateParticipantHandler(ApplicationDbContext ctx, IPermissionChecker pc)
    {
        _ctx = ctx;
        _pc = pc;
    }

  public async Task<Result<Guid>> Handle(CreateParticipantCommand command, CancellationToken token)
    {
        var p = new Participant { Id = Guid.NewGuid(), Name = command.Name, BranchId = command.BranchId };
        _ctx.Add(p); _ctx.SaveChanges();
        return p.Id;
    }
}