
using Microsoft.EntityFrameworkCore;
using School_API.Core.Models;
using School_API.Infrastructure.Persistence;

namespace School_API.Infrastructure.Repositories
{
    public class PeriodRepository
    {
        private readonly SchoolApiContext _context;

        public PeriodRepository(SchoolApiContext context)
        {
            _context = context;
        }

        public async Task<Period?> GetLastPeriod()
        {
            return await _context.Periods.OrderByDescending(p => p.Id).FirstOrDefaultAsync();
        }
    }
}