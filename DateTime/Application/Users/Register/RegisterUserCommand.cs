using DateTime.Application.Abstractions.Messaging;


namespace DateTime.Application.Users.Register;

public record RegisterUserCommand(string email, string password) : ICommand<string>;