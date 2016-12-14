using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using redball.Models;

namespace redball.Controllers
{
    public class HomeController : Controller
    {
        private redball_basic_dbContext _context;

        public HomeController(redball_basic_dbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ship()
        {
            var serviceTypes = _context.TblPlServiceType.Include(x => x.TblPlTrailerType);
            return View(serviceTypes);
        }

        public IActionResult Edit()
        {
            // Overrides may be requeried
            ViewData["Overrides"] = _context.TblShipperRateOverride
                .Include(x => x.SroShipper)
                .Include(x => x.SroOriginStateCodeNavigation)
                .Include(x => x.SroTargetStateCodeNavigation);
            // Benchmarks loaded easily
            ViewData["Benchmark"] = _context.TblTnsbenchmarkRate
                .Include(x => x.TbrOriginStateCodeNavigation)
                .Include(x => x.TbrTargetStateCodeNavigation)
                .ToList();
            return View(ViewData);
        }

        public IActionResult Profile()
        {
            return View(_context.TblShipper.ToList());
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
