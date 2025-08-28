using VendasMvcWeb.Data;
using VendasMvcWeb.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace VendasMvcWeb.Services
{
    public class DepartmentService
    {
        private readonly VendasMvcWebContext _context;
        public DepartmentService(VendasMvcWebContext context)
        {
            _context = context;
        }
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
        public void Insert(Department obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Department FindById(int id)
        {
            return _context.Department.Include(obj => obj.Sellers).FirstOrDefault(obj => obj.Id == id);
        }
    }
}
