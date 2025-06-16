using DateTime.Application.Abstractions.Messaging;
using DateTime.Domain.Abstractions;
using DateTime.Domain.Models.Participants;

namespace DateTime.Application.Participants;

public class GetParticipantQueryHandler : IQueryHandler<GetParticipantQuery, ParticipantDto>
{
    private readonly IParticipantRepository _participantRepository;

    public GetParticipantQueryHandler(IParticipantRepository participantRepository)
    {
        _participantRepository = participantRepository;
    }

    public async Task<Result<ParticipantDto>> Handle(GetParticipantQuery query, CancellationToken token)
    {
        var participant = await _participantRepository.GetByName(query.name);
        return participant;
    }
}