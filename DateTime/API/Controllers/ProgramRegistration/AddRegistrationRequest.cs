namespace DateTime.API.Controllers.ProgramRegistration;

public record AddRegistrationRequest(long programId, long UserId, string location);