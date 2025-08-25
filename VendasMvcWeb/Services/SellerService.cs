using VendasMvcWeb.Data;
using VendasMvcWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasMvcWeb.Services
{
    public class SellerService
    {
        private readonly VendasMvcWebContext _context;

        public SellerService(VendasMvcWebContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

         }
        
       
        }
    }
