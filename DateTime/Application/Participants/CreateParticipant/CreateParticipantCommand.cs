using DateTime.Application.Abstractions.Messaging;
using MediatR;

namespace DateTime.Application.Participants;
public record CreateParticipantCommand(string Name, Guid BranchId) : ICommand<Guid>;