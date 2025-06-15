using DateTime.Application.Abstractions.Messaging;

namespace DateTime.Application.Users.Register;

public record RegisterUserCommand(string email, string userName, string password, string role) : ICommand<string>;