namespace DateTime.Domain.Models.Program;

public interface IProgramRepository
{
    Task Add(Programs program);
    Task<Programs?> GetById(string id);
    Task<List<ProgramDto?>> GetAll(string timezoneId);
    Task<List<Programs?>> GetByLocation(string location);
}

