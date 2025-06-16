
using DateTime.Application.Abstractions.Messaging;

namespace DateTime.Application.ProgramRegistration.AddRegistration;

public record AddRegistrationCommand(string programId, string UserId, string location, string branchId) : ICommand<string>;