using DateTime.Application.Abstractions.Messaging;
using DateTime.Domain.Abstractions;
using DateTime.Domain.Models.Participants;

namespace DateTime.Application.Participants;

public class ListParticipantsQueryHandler : IQueryHandler<ListParticipantsQuery, List<ParticipantDto>>
{
    private readonly IParticipantRepository _participantRepository;

    public ListParticipantsQueryHandler(IParticipantRepository participantRepository)
    {
        _participantRepository = participantRepository;
    }

    public async Task<Result<List<ParticipantDto>>> Handle(ListParticipantsQuery query, CancellationToken token)
    {
        var participants = await _participantRepository.GetByBranchId(query.branchId);
        return participants;
    }
}