﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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
            ViewData["Overrides"] = _context.TblShipperRateOverride
                .Include(x => x.SroShipper)
                .Include(x => x.SroOriginStateCodeNavigation)
                .Include(x => x.SroTargetStateCodeNavigation);
            ViewData["Benchmark"] = _context.TblTnsbenchmarkRate
                .Include(x => x.TbrOriginStateCodeNavigation)
                .Include(x => x.TbrTargetStateCodeNavigation);
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
