using DateTime.Domain.ProgramRegistrations;
using DateTime.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DateTime.Infrastructure.Repositories;

public class ProgramRegistrationRepository : IProgramRegistrationRepository
{
    private readonly ApplicationDbContext _context;

    public ProgramRegistrationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(ProgramRegistration registration)
    {
        if (registration is null)
        {
            throw new ArgumentNullException(nameof(registration), "Registration cannot be null.");
        }
        await _context.Set<ProgramRegistration>().AddAsync(registration);
        await _context.SaveChangesAsync();
    }

    public async Task<List<ProgramRegistration>> GetByProgramId(long id)
    {
        return await _context.Set<ProgramRegistration>().Where(reg => reg.ProgramId == id).ToListAsync();
    }
}