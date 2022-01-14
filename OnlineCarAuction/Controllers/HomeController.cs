using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineCarAuction.Models;
using OnlineCarAuction.Repository;

namespace OnlineCarAuction.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository<Car> _repoCar;

        public HomeController(ILogger<HomeController> logger, IRepository<Car> repoCar)
        {
            _logger = logger;
            _repoCar = repoCar;
        }

        public IActionResult Index()
        {
            var cars = _repoCar.GetAll();
            return View(cars);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
