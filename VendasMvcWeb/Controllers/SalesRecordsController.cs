using Microsoft.AspNetCore.Mvc;

namespace VendasMvcWeb.Controllers
{
    public class SalesRecordsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SimpleSearch()
        {
            return View();
        }
        public IActionResult GroupinSearch()
        {
            return View();
        }
    }
}
