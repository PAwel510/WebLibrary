using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebLibrary.Models;
using WebLibrary.Services;

namespace WebLibrary.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookService _bookService;

        public HomeController(ILogger<HomeController> logger, BookService service)
        {
            _logger = logger;
            this._bookService = service;
            
        }
        [Route("/")]
        
        public IActionResult Index()
        {
            return View();
        }
        [Route("/Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
        [Route("/AddNew")]
        [HttpGet]
        public IActionResult AddNew()
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
