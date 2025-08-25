using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VendasMvcWeb.Models;
using VendasMvcWeb.Services;

namespace VendasMvcWeb.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        // Lista de vendedores
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        // GET: Create
        public IActionResult Create()
        {
            ViewData["Title"] = "Create Seller";

            var departments = _departmentService.FindAll() ?? new List<Department>();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");

            return View(new Seller());
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll() ?? new List<Department>();
                ViewBag.Departments = new SelectList(departments, "Id", "Name");

                return View(seller);
            }

            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
