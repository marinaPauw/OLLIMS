using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OLLIMS.Models;
using OLLIMS.Data;

namespace OLLIMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DBContext _context;
        public HomeController(ILogger<HomeController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Instruments()
        {
            var instruments = _context.Instruments.ToList();
            if (instruments == null)
            {
                Console.WriteLine("There are no instruments added yet.");
            }
            return View(instruments);
        }

        public IActionResult Instrument(int ID)
        {
            var instrument = _context.Instruments.SingleOrDefault(p => p.ID == ID);
            var vm = new InstrumentViewModel
            {
                Instrument = instrument
            };

            if (instrument != null)
            {
                return View(vm);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
