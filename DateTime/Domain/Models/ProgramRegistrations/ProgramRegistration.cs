
using DateTime.Domain.Models.Branches;
using DateTime.Domain.Models.Program;
using DateTime.Domain.Models.Users;


namespace DateTime.Domain.Models.ProgramRegistrations;

public class ProgramRegistration
{
    public string Id { get; set; }
    public string ProgramId { get; set; }
    public Programs Program { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public string Location { get; set; }
    public string BranchId { get; set; }
    public Branch Branch { get; set; }
    public System.DateTime RegisteredAt { get; set; }

    private ProgramRegistration() { }

    public ProgramRegistration(string programId, string userId, string location, string branchId, System.DateTime registeredAt)
    {
        ProgramId = programId;
        UserId = userId;
        Location = location;
        BranchId = branchId;
        RegisteredAt = registeredAt;
    }

    public static ProgramRegistration Create(string programId, string userId, string location, string branchId, System.DateTime registeredAt)
    {
        var registration = new ProgramRegistration(programId, userId, location, branchId, registeredAt);
        return registration;
    }

}