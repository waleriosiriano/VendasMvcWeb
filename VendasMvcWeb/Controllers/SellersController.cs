using Microsoft.AspNetCore.Mvc;

namespace VendasMvcWeb.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
