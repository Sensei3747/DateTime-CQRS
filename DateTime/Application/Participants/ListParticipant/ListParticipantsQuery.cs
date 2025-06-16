using DateTime.Application.Abstractions.Messaging;
using DateTime.Domain.Models.Participants;

namespace DateTime.Application.Participants;

public record ListParticipantsQuery(string branchId) : IQuery<List<ParticipantDto>>;