using DateTime.Domain.Models.Participants;
using DateTime.Domain.Models.Users;
using DateTime.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DateTime.Infrastructure.Repositories;

public class ParticipantRepository : IParticipantRepository
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _manager;

    public ParticipantRepository(ApplicationDbContext context, UserManager<User> manager)
    {
        _context = context;
        _manager = manager;
    }

    public async void Add(Participant participant)
    {
        if (participant is null)
        {
            throw new ArgumentNullException(nameof(participant), "Participant cannot be null");
        }
        await _context.Set<Participant>().AddAsync(participant);
        await _context.SaveChangesAsync();
    }

    public async Task<List<ParticipantDto>> GetByBranchId(string branchId)
    {
        var participants = await _context.Set<Participant>().Where(p => p.BranchId == branchId)
                                   .Select(p => new ParticipantDto
                                   {
                                       Id = p.Id,
                                       Name = p.Name,
                                       BranchId = p.BranchId,
                                       CreatedByUserId = p.CreatedByUserId
                                   }).ToListAsync();
        return participants;
    }

    public async Task<ParticipantDto> GetByName(string name)
    {
        var participant = await _context.Set<Participant>().Where(p => p.Name == name)
                                  .Select(p => new ParticipantDto
                                  {
                                      Id = p.Id,
                                      Name = p.Name,
                                      BranchId = p.BranchId,
                                      CreatedByUserId = p.CreatedByUserId
                                  }).FirstOrDefaultAsync();
        return participant;
    }

    public async void Delete(string name)
    {
        await _context.Set<Participant>().Where(p => p.Name == name).ExecuteDeleteAsync();
    }

    public async Task<List<ParticipantDto>> GetByUserId(string userId)
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
            "SuperAdmin" or "Admin" => await _context.Set<Participant>()
                                                     .Select(p => new ParticipantDto
                                                     {
                                                         Id = p.Id,
                                                         Name = p.Name,
                                                         BranchId = p.BranchId,
                                                         CreatedByUserId = p.CreatedByUserId
                                                     }).ToListAsync(),

            "BranchManager" => await _context.Set<Participant>()
                                             .Where(p => p.BranchId == user.BranchId)
                                             .Select(p => new ParticipantDto
                                             {
                                                 Id = p.Id,
                                                 Name = p.Name,
                                                 BranchId = p.BranchId,
                                                 CreatedByUserId = p.CreatedByUserId
                                             }).ToListAsync(),

            "Staff" => await _context.Set<Participant>()
                                     .Where(p => p.BranchId == user.BranchId && p.CreatedByUserId == user.Id)
                                     .Select(p => new ParticipantDto
                                     {
                                         Id = p.Id,
                                         Name = p.Name,
                                         BranchId = p.BranchId,
                                         CreatedByUserId = p.CreatedByUserId
                                     }).ToListAsync(),

            _ => []
        };
    }
    
}