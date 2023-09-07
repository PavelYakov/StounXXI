using Microsoft.AspNetCore.Mvc;
using StounXXI.Models;
using StounXXI.Services;

namespace StounXXI.Controllers
{
    public class CandidatController : Controller
    {
        private readonly HhApiService _hhApiService;

        public CandidatController(HhApiService hhApiService)
        {
            _hhApiService = hhApiService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var candidates = await _hhApiService.GetAllCandidatesAsync();
                return View(candidates);
            }
            catch (HttpRequestException ex)
            {
                
                return View("Error", ex.Message);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var candidate = await _hhApiService.GetCandidateAsync(id);

                if (candidate == null)
                {
                    return NotFound();
                }

                return View(candidate);
            }
            catch (HttpRequestException ex)
            {
                
                return View("Error", ex.Message);
            }
        }

       
    }
}
