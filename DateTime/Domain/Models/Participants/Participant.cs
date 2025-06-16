using DateTime.Domain.Models.Branches;
using DateTime.Domain.Models.Users;

namespace DateTime.Domain.Models.Participants;

public class Participant
{
    public string Id { get; set; }
    public string Name { get; set; } = null!;
    public System.DateTime RegisteredAt { get; set; } = System.DateTime.UtcNow;

    public string BranchId { get; set; }
    public Branch Branch { get; set; } = null!;

    public string CreatedByUserId { get; set; }
    public User CreatedByUser { get; set; } = null!;

    public Participant() { }

    public Participant(string name, string branchId, string createdByUserId)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        BranchId = branchId;
        CreatedByUserId = createdByUserId;
    }

    public static Participant Create(string name, string branchId, string createdByUserId)
    {
        var participant = new Participant(name, branchId, createdByUserId);
        return participant;
    }

}