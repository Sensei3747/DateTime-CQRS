using DateTime.Application.Abstractions.Messaging;
using DateTime.Domain.Abstractions;
using DateTime.Domain.Program;

namespace DateTime.Application.Program.AddProgram;

internal sealed class AddProgramCommandHandler : ICommandHandler<AddProgramCommand, string>
{
    private readonly IProgramRepository _programRepository;

    public AddProgramCommandHandler(IProgramRepository programRepository)
    {
        _programRepository = programRepository;
    }

    public async Task<Result<string>> Handle(AddProgramCommand command, CancellationToken token)
    {
        var istZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Kolkata");
        var utcZone = TimeZoneInfo.Utc;
        var istStart = System.DateTime.SpecifyKind(command.startTime, DateTimeKind.Unspecified);
        var istEnd = System.DateTime.SpecifyKind(command.endTime, DateTimeKind.Unspecified);
        System.DateTime utcTimeStart = TimeZoneInfo.ConvertTime(istStart, istZone, utcZone);
        System.DateTime utcTimeEnd = TimeZoneInfo.ConvertTime(istEnd, istZone, utcZone); 
        var program = Programs.Create(command.name, command.location, utcTimeStart, utcTimeEnd, command.price, command.limit);
        await _programRepository.Add(program);
        return $"Program Added Successfull with name : {program.Name}";
    }
}