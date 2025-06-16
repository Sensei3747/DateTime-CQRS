using DateTime.Application.Abstractions.Timezone;
using DateTime.Domain.Models.Program;
using DateTime.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DateTime.Infrastructure.Repositories;

public class ProgramRepository : IProgramRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ITimezoneHelper _timezoneHelper;

    public ProgramRepository(ApplicationDbContext context, ITimezoneHelper timezoneHelper)
    {
        _timezoneHelper = timezoneHelper;
        _context = context;
    }

    public async Task Add(Programs program)
    {
        if (program is null)
        {
            throw new ArgumentNullException(nameof(program), "Program cannot be null.");
        }
        await _context.Set<Programs>().AddAsync(program);
        await _context.SaveChangesAsync();
    }

    public async Task<Programs?> GetById(string id)
    {
        var program = await _context.Set<Programs>().Where(pgm => pgm.Id == id).FirstOrDefaultAsync();
        return program;
    }
    public async Task<List<ProgramDto>> GetAll(string timezoneId)
    {
        var programs = await _context.Set<Programs>()
                .Select(pgm => new ProgramDto
                {
                    Name = pgm.Name,
                    Location = pgm.Location,
                    Price = pgm.Price,
                    LocalStartTime = _timezoneHelper.ConvertToTimezone(pgm.StartTime, timezoneId),
                    LocalEndTime = _timezoneHelper.ConvertToTimezone(pgm.EndTime, timezoneId),
                    Limit = pgm.Limit
                })
                .ToListAsync();
        return programs;
    }

    public async Task<List<Programs>> GetByLocation(string location)
    {
        return await _context.Set<Programs>().Where(pgm => pgm.Location == location).ToListAsync();
    }
}