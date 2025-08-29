using Microsoft.EntityFrameworkCore;
using VendasMvcWeb.Data;
using VendasMvcWeb.Models;

namespace VendasMvcWeb.Services
{
    public class SalesRecordService
    {
        private readonly VendasMvcWebContext _context;
        public SalesRecordService(VendasMvcWebContext context)
        {
            _context = context;
        }
        public async Task <List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

    }
}
