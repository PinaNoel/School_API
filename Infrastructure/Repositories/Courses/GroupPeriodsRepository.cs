

using Microsoft.EntityFrameworkCore;
using School_API.App.DTO;
using School_API.Core.Models;
using School_API.Infrastructure.Persistence;

namespace School_API.Infrastructure.Repositories
{
    public class GroupPeriodsRepository
    {


        private readonly SchoolApiContext _context;


        public GroupPeriodsRepository(SchoolApiContext context)
        {
            _context = context;
        }


        public async Task<List<GroupResponseDTO>> GetGroups()
        {
            return await _context.Groups.Select(g => new GroupResponseDTO { Id = g.Id, Group = g.Name! }).ToListAsync();
        }


        public async Task<List<PeriodResponseDTO>> GetPeriods()
        {
            return await _context.Periods.Select(p => new PeriodResponseDTO { Id = p.Id, Period = p.Name! }).ToListAsync();
        }


        public async Task RegisterNewGroupPeriod(GroupPeriod groupPeriod)
        {
            await _context.GroupPeriods.AddAsync(groupPeriod);
        }


        public async Task NewActualPeriod(ActualPeriodSubject actualPeriod)
        {
            await _context.ActualPeriodSubjects.AddAsync(actualPeriod);
        }


    }
}