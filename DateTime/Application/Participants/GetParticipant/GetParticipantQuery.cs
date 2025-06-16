using DateTime.Application.Abstractions.Messaging;
using DateTime.Domain.Models.Participants;

namespace DateTime.Application.Participants;

public record GetParticipantQuery(string name) : IQuery<ParticipantDto>;