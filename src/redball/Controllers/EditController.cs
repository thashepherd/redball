using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using redball.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace redball.Controllers
{
    public class EditController : Controller
    {
        private redball_basic_dbContext _context;

        public EditController(redball_basic_dbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            // Overrides may be requeried
            ViewData["Overrides"] = _context.TblShipperRateOverride
                .Include(x => x.SroShipper)
                .Include(x => x.OriginStateCodeNavigation)
                .Include(x => x.TargetStateCodeNavigation);
            // Benchmarks loaded easily
            ViewData["Benchmark"] = _context.TblTnsbenchmarkRate
                .Include(x => x.TbrOriginStateCodeNavigation)
                .Include(x => x.TbrTargetStateCodeNavigation)
                .ToList();
            return View(ViewData);
        }
    }
}
