using Microsoft.AspNetCore.Mvc;
using StounXXI.Models;

namespace StounXXI.Controllers
{
    public class HRController : Controller
    {
        private readonly ApplicationContext _context;
        public HRController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var hr = _context.HR.ToList();
            return View(hr);
        }
        public IActionResult Details(int id)
        {
            var hr = _context.HR
                                             .FirstOrDefault(e => e.Id == id);


            if (hr == null)
            {
                return NotFound();
            }
            return View(hr);
        }
    }
}
