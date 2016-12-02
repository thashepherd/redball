using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            return View(_context.TblShipper.ToList());
        }

        public IActionResult Edit()
        {
            return View(_context.TblTnsbenchmarkRate.ToList());
        }

        public IActionResult Profile()
        {
            return View(_context.TblShipperOrigin.ToList());
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
