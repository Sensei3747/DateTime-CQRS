namespace DateTime.Domain.Models.ProgramRegistrations;

public interface IProgramRegistrationRepository
{
    Task Add(ProgramRegistration registration);
    Task<List<ProgramRegistration?>> GetByProgramId(long id);
}