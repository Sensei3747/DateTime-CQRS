using DateTime.Domain.Models.Participants;
using DateTime.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DateTime.Infrastructure.Repositories;

public class ParticipantRepository : IParticipantRepository
{
    private readonly ApplicationDbContext _context;

    public ParticipantRepository(ApplicationDbContext context)
    {
        _context = context;
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
}