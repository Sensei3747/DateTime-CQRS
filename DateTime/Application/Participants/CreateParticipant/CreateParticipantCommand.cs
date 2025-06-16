using DateTime.Application.Abstractions.Messaging;
using MediatR;

namespace DateTime.Application.Participants;

public record CreateParticipantCommand(string name, string branchId, string createdByUserId) : ICommand<string>;