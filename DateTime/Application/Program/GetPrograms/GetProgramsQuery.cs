using DateTime.Application.Abstractions.Messaging;
using DateTime.Domain.Models.Program;

namespace DateTime.Application.Program.GetPrograms;

public record GetProgramsQuery(string timezone) : IQuery<List<ProgramDto?>>;