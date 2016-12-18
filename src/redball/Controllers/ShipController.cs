using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using redball.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace redball.Controllers
{
    public class ShipController : Controller
    {
        private redball_basic_dbContext _context;

        public ShipController(redball_basic_dbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewData["States"] = _context.TblState;
            ViewData["ServiceTypes"] = _context.TblPlServiceType.Include(x => x.TblPlTrailerType);
            // Overrides may be requeried
            ViewData["Overrides"] = _context.TblShipperRateOverride
                .Include(x => x.SroShipper)
                .Include(x => x.SroOriginState)
                .Include(x => x.SroTargetState);
            // Benchmarks loaded easily
            ViewData["Benchmark"] = _context.TblTnsbenchmarkRate
                .Include(x => x.TbrOriginState)
                .Include(x => x.TbrTargetState)
                .ToList();
            return View(ViewData);
        }
    }
}
