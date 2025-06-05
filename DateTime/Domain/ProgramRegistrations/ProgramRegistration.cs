
using DateTime.Domain.Program;
using DateTime.Domain.Users;

namespace DateTime.Domain.ProgramRegistrations;

public class ProgramRegistration
{
    public long Id { get; set; }
    public long ProgramId { get; set; }
    public Programs Program { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public string Location { get; set; }
    public System.DateTime RegisteredAt { get; set; }

    private ProgramRegistration() { }

    public ProgramRegistration(long programId, long userId, string location, System.DateTime registeredAt)
    {
        ProgramId = programId;
        UserId = userId;
        Location = location;
        RegisteredAt = registeredAt;
    }

    public static ProgramRegistration Create(long programId, long userId, string location, System.DateTime registeredAt)
    {
        var registration = new ProgramRegistration(programId, userId, location, registeredAt);
        return registration;
    }

}