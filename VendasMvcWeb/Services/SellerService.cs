using VendasMvcWeb.Data;
using VendasMvcWeb.Models;
namespace VendasMvcWeb.Services
{
    public class SellerService
    {
    
        private readonly VendasMvcWebContext _context;

        public SellerService(VendasMvcWebContext? context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
