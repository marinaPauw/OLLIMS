using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OLLIMS.Models;
using OLLIMS.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

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
            InstrumentCatalogueViewModel vm;
            if (_context.Instruments.Local.Count() > 0)
            {
                var instruments = GetAllInstruments();
                vm = new InstrumentCatalogueViewModel
                {
                    instruments = instruments
                };
            }
            else 
            {
            //Create viewmodel for nothing to display yet.
                vm = new InstrumentCatalogueViewModel
                {
                    instruments = new List<Instrument>()
                };
            }
            return View(vm);
        }

        public IActionResult Laboratories()
        {
            LaboratoryCatalogueViewModel vm;
            if (_context.Laboratories.Local.Count() > 0)
            {
                var labs = GetAllLaboratories();
                vm = new LaboratoryCatalogueViewModel
                {
                    Laboratories = labs
                };
            }
            else
            {
                //Create viewmodel for nothing to display yet.
                vm = new LaboratoryCatalogueViewModel
                {
                    Laboratories = new List<Laboratory>()
                };
            }
            return View(vm);
        }
        public List<Laboratory> GetAllLaboratories()
        {
            var labs = _context.Laboratories.ToList();
            if (labs == null)
            {
                throw new EntityNotFoundException("Any lab", 0);
            }
            return labs;
        }
        public Laboratory GetLabById(int ID)
        {
            var lab = _context.Laboratories.SingleOrDefault(p => p.ID == ID);
            if (lab == null)
            {
                throw new EntityNotFoundException(nameof(lab), ID);
            }
            return lab;
        }
        public IActionResult Laboratory(int ID)
        {
            var lab = GetLabById(ID);
            var vm = new LaboratoryViewModel
            {
                Laboratory = lab
            };

            return View(vm);

        }
        public List<Instrument> GetAllInstruments()
        {
            var instruments = _context.Instruments.ToList();
            if (instruments == null)
            {
                throw new EntityNotFoundException("Any instrument", 0);
            }
            return instruments;
        }
        public Instrument GetInstrumentById(int ID)
        {
            var instrument = _context.Instruments.SingleOrDefault(p => p.ID == ID);
            if (instrument == null)
            {
                throw new EntityNotFoundException(nameof(instrument), ID);
            }
            return instrument;
        }
        public IActionResult Instrument(int ID)
        {
            var instrument = GetInstrumentById(ID);
            var vm = new InstrumentViewModel
            {
                Instrument = instrument
            };

            return View(vm);
            
        }
        public class EntityNotFoundException : Exception
        {
            public EntityNotFoundException(string name, object key)
                : base($"Entity '{name}' ({key}) was not found.")
            {
            }
        }
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class ExceptionFilter : ExceptionFilterAttribute
        {
            public override void OnException(ExceptionContext context)
            {
                var statusCode = HttpStatusCode.InternalServerError;

                if (context.Exception is EntityNotFoundException)
                {
                    statusCode = HttpStatusCode.NotFound;
                }

                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)statusCode;
                context.Result = new JsonResult(new
                {
                    error = new[] { context.Exception.Message },
                    stackTrace = context.Exception.StackTrace
                });
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
