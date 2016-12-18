using Microsoft.AspNetCore.Mvc;
using redball.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace redball.Controllers
{
    public class ShipperRateOverrideController : Controller
    {
        // GET: /<controller>/

        [HttpPost]
        public IActionResult Index([FromBody]ShipperRateOverride shipperRateOverride)
        {
            return Json(shipperRateOverride);
        }
    }
}
