namespace DateTime.Domain.Models.Participants;

public interface IParticipantRepository
{
    void Add(Participant participant);
    Task<List<ParticipantDto>> GetByBranchId(string branchId);
    Task<ParticipantDto> GetByName(string name);
    void Delete(string name);
    Task<List<ParticipantDto>> GetByUserId(string userId);
}