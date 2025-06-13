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
}