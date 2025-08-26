using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            var departments = _departmentService.FindAll() ?? new List<Department>();
            ViewBag.Departments = new SelectList(departments, "Id", "Name", obj.DepartmentId);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll() ?? new List<Department>();
                ViewBag.Departments = new SelectList(departments, "Id", "Name", seller.DepartmentId);
                return View(seller);
            }
            try
            {
                _sellerService.Update(seller);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
