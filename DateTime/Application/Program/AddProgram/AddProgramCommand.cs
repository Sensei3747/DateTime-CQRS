using DateTime.Application.Abstractions.Messaging;

namespace DateTime.Application.Program.AddProgram;

public record AddProgramCommand(string name, string location, System.DateTime startTime, System.DateTime endTime, decimal price, int limit ) : ICommand<string>;