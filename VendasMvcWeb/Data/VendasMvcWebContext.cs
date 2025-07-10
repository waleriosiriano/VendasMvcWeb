using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendasMvcWeb.Models;

namespace VendasMvcWeb.Data
{
    public class VendasMvcWebContext : DbContext
    {
        public VendasMvcWebContext (DbContextOptions<VendasMvcWebContext> options)
            : base(options)
        {
        }

        public DbSet<VendasMvcWeb.Models.Department> Department { get; set; } = default!;
    }
}
