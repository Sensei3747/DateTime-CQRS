using DateTime.Domain.Branches;
using DateTime.Domain.Users;

namespace DateTime.Domain.Participants;
public class Participant
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public System.DateTime RegisteredAt { get; set; } = System.DateTime.UtcNow;

    public Guid BranchId { get; set; }
    public Branch Branch { get; set; } = null!;

    public Guid CreatedByUserId { get; set; }
    public User CreatedByUser { get; set; } = null!;
}