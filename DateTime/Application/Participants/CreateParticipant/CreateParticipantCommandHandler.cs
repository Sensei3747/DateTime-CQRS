using DateTime.Application.Abstractions.Messaging;
using DateTime.Application.Abstractions.Services;
using DateTime.Domain.Abstractions;
using DateTime.Domain.Models.Participants;
using DateTime.Infrastructure.Data;


namespace DateTime.Application.Participants;

public class CreateParticipantHandler : ICommandHandler<CreateParticipantCommand, string>
{
  private readonly IParticipantRepository _participantRepository;
  private readonly IUnitOfWork _unitOfWork;
  //private readonly IPermissionChecker _pc;

  public CreateParticipantHandler(IParticipantRepository participantRepository, IUnitOfWork unitOfWork)
  {
    _participantRepository = participantRepository;
    _unitOfWork = unitOfWork;
    //_pc = pc;
  }

  public async Task<Result<string>> Handle(CreateParticipantCommand command, CancellationToken token)
  {
    var p = Participant.Create(command.name, command.branchId, command.createdByUserId);
    _participantRepository.Add(p);
    await _unitOfWork.SaveChangesAsync();
    return p.Id;
  }
}