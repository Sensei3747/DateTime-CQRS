namespace DateTime.API.Controllers.ProgramRegistration;

public record AddRegistrationRequest(string programId, string UserId, string location, string branchId);