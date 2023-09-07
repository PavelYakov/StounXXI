using Microsoft.AspNetCore.Mvc;
using StounXXI.Models;
using System.Data.Entity;

namespace StounXXI.Controllers
{
    public class VacantionController : Controller
    {
        private readonly ApplicationContext _context;
        public VacantionController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var vacancies = _context.Vacancies.ToList();
            return View(vacancies);
        }
        public IActionResult Details(int id)
        {
            var vacancies    = _context.Vacancies
                                             .Include(e=>e.Department)
                                             .FirstOrDefault(e => e.Id == id);


            if (vacancies == null)
            {
                return NotFound();
            }
            return View(vacancies);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {

            _context.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
