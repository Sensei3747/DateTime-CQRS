namespace DateTime.Domain.Program;

public interface IProgramRepository
{
    Task Add(Programs program);
    Task<Programs?> GetById(long id);
    Task<List<ProgramDto?>> GetAll(string timezoneId);
    Task<List<Programs?>> GetByLocation(string location);
}

