using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using OnlineCarAuction.Models;
using OnlineCarAuction.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCarAuction.Controllers
{
    public class CarController : Controller
    {
        private readonly ILogger<CarController> _logger;
        private IRepository<Bid> _repoBid;
        private IRepository<Car> _repoCar;

        public CarController(ILogger<CarController> logger, IRepository<Car> repoCar, IRepository<Bid> repoBid)
        {
            _logger = logger;
            _repoCar = repoCar;
            _repoBid = repoBid;

        }

        // GET: HomeController1
        public ActionResult Index()
        {
            var cars = _repoCar.GetAll();
            return View(cars);
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Car car = new Car();
                car.Name = collection["Name"].ToString();
                car.Brand = collection["Brand"].ToString();
                car.ProductionYear = int.Parse(collection["ProductionYear"]);
                car.StartPrice = int.Parse(collection["StartPrice"]);


                _repoCar.Insert(car);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            Car carToEdit = _repoCar.Get(id);
            return View(carToEdit);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Car carToUpdate = _repoCar.Get(id);
                carToUpdate.Name = collection["Name"].ToString();
                carToUpdate.Brand = collection["Brand"].ToString();
                carToUpdate.ProductionYear = int.Parse(collection["ProductionYear"]);
                carToUpdate.StartPrice = int.Parse(collection["StartPrice"]);
                _repoCar.Update(carToUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            Car carToDelete = _repoCar.Get(id);
            return View(carToDelete);
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Car carToDelete = _repoCar.Get(id);
                _repoCar.Delete(carToDelete);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Bid(int id)
        {
            Car car = _repoCar.Get(id);
            ViewData["Brand"] = car.Brand;
            ViewData["Name"] = car.Name;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Bid(int id, IFormCollection collection)
        {
            try
            {
                Bid bid = new Bid();
                bid.Rate = int.Parse(collection["Rate"]);
                bid.CarId = id;

                _repoBid.Insert(bid);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Bids(int id)
        {
            var bids = _repoBid.GetAll();
            List<Bid> filteredBids = new List<Bid>();
            foreach (var b in bids)
            {
                if (b.CarId == id)
                    filteredBids.Add(b);
            }

            ViewData["carId"] = id.ToString();
            return View(filteredBids);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBid(int id, string carId, IFormCollection collection)
        {
            try
            {
                Bid bidToDelete = _repoBid.Get(id);
                _repoBid.Delete(bidToDelete);
                return RedirectToAction("Index", "Car");
            }
            catch
            {
                return RedirectToAction("Bids", "Car");
            }
        }
    }
}