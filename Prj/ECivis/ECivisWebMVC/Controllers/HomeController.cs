using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECivisWebMVC.Models;
using ECivisObj.Models;
using Microsoft.EntityFrameworkCore;

namespace ECivisWebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly NGORoboticsContext _context;

        public HomeController(NGORoboticsContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Category.ToListAsync();

            ViewData["categories"] = categories;
            return View();
        }
        public async Task<IActionResult> ViewCategory(int id)
        {
            return Content("ai vazut categoria " + id);
        }

            public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
