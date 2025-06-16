using DateTime.Application.Abstractions.Messaging;
using DateTime.Domain.Abstractions;
using DateTime.Domain.Models.Participants;

namespace DateTime.Application.Participants;

public class GetParticipantsForUserTypeQueryHandler : IQueryHandler<GetParticipantsForUserTypeQuery, List<ParticipantDto>>
{
    private readonly IParticipantRepository _participantRepository;

    public GetParticipantsForUserTypeQueryHandler(IParticipantRepository participantRepository)
    {
        _participantRepository = participantRepository;
    }

    public async Task<Result<List<ParticipantDto>>> Handle(GetParticipantsForUserTypeQuery query, CancellationToken token)
    {
        var participants = await _participantRepository.GetByUserId(query.userId);
        return participants;
    }
}