using DateTime.Application.Abstractions.Messaging;
using DateTime.Domain.Program;

namespace DateTime.Application.Program.GetPrograms;

public record GetProgramsQuery(string timezone) : IQuery<List<ProgramDto?>>;