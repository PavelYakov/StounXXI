using Microsoft.AspNetCore.Mvc;
using StounXXI.Models;

namespace StounXXI.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationContext _context;
        public DepartmentController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }
        public IActionResult Details(int id)
        {
            var department = _context.Departments
                                             .FirstOrDefault(e => e.Id == id);


            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
    }
}
