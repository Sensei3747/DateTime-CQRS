using DateTime.Application.Abstractions.Messaging;
using DateTime.Domain.Abstractions;
using DateTime.Domain.Program;

namespace DateTime.Application.Program.GetPrograms;

internal sealed class GetProgramsQueryHandler : IQueryHandler<GetProgramsQuery, List<ProgramDto?>>
{
    private readonly IProgramRepository _programRepository;

    public GetProgramsQueryHandler(IProgramRepository programRepository)
    {
        _programRepository = programRepository;
    }

    public async Task<Result<List<ProgramDto?>>> Handle(GetProgramsQuery request, CancellationToken token)
    {
        var programs = await _programRepository.GetAll(request.timezone);
        return programs;
    }
}