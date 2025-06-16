using DateTime.Domain.Models.ProgramRegistrations;
using DateTime.Domain.Models.Users;
using DateTime.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DateTime.Infrastructure.Repositories;

public class ProgramRegistrationRepository : IProgramRegistrationRepository
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _manager;

    public ProgramRegistrationRepository(ApplicationDbContext context, UserManager<User> manager)
    {
        _context = context;
        _manager = manager;
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

    public async Task<List<ProgramRegistration>> GetByProgramId(string id)
    {
        return await _context.Set<ProgramRegistration>().Where(reg => reg.ProgramId == id).ToListAsync();
    }

    public async Task<List<ProgramRegistrationDto>> GetByUserId(string userId)
    {
        var user = await _context.Set<User>().Where(u => u.Id == userId).FirstOrDefaultAsync();
        if (user is null)
        {
            return [];
        }
        var roles = await _manager.GetRolesAsync(user);
        var role = roles[0];
        return role switch
        {
            "SuperAdmin" or "Admin" => await _context.Set<ProgramRegistration>()
                                                     .Select(pr => new ProgramRegistrationDto
                                                     {
                                                         ProgramId = pr.ProgramId,
                                                         BranchId = pr.BranchId,
                                                         Location = pr.Location,
                                                         UserId = pr.UserId,
                                                         RegisteredAt = pr.RegisteredAt
                                                     }).ToListAsync(),

            "BranchManager" => await _context.Set<ProgramRegistration>()
                                             .Where(pr => pr.BranchId == user.BranchId)
                                             .Select(pr => new ProgramRegistrationDto
                                             {
                                                 ProgramId = pr.ProgramId,
                                                 BranchId = pr.BranchId,
                                                 Location = pr.Location,
                                                 UserId = pr.UserId,
                                                 RegisteredAt = pr.RegisteredAt
                                             }).ToListAsync(),

            "Staff" => await _context.Set<ProgramRegistration>()
                                     .Where(pr => pr.BranchId == user.BranchId && pr.UserId == user.Id)
                                     .Select(pr => new ProgramRegistrationDto
                                     {
                                         ProgramId = pr.ProgramId,
                                         BranchId = pr.BranchId,
                                         Location = pr.Location,
                                         UserId = pr.UserId,
                                         RegisteredAt = pr.RegisteredAt
                                     }).ToListAsync(),
            _ => []
        };
    }
}