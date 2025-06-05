
using DateTime.Application.Abstractions.Messaging;

namespace DateTime.Application.ProgramRegistration.AddRegistration;

public record AddRegistrationCommand(long programId, long UserId, string location): ICommand<string>;