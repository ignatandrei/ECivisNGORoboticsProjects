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
        public async Task<IActionResult> Index(int? id)
        {
            
            
            var categories = await _context.Category.ToListAsync();
            ViewData["categories"] = categories;

            var search = "TOATE";
            if (id != null)
            {
                search = categories.First(it => it.Id == id).Name;
            }
            ViewData["search"] = search;

            var details = await _context.DetailsRobotics(id);
            ViewData["allRobo"] = details;
            return View();
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
