using DateTime.Application.Abstractions.Messaging;
using DateTime.Domain.Models.Participants;

namespace DateTime.Application.Participants;

public record GetParticipantsForUserTypeQuery(string userId) : IQuery<List<ParticipantDto>>;