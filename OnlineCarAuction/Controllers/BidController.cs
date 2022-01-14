using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineCarAuction.Models;
using OnlineCarAuction.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCarAuction.Controllers
{
    public class BidController : Controller
    {
        private readonly ILogger<BidController> _logger;
        private IRepository<Bid> _repoBid;

        public BidController(ILogger<BidController> logger, IRepository<Bid> repoBid)
        {
            _logger = logger;
            _repoBid = repoBid;

        }

        // GET: BidController/Edit/5
        public ActionResult Edit(int id)
        {
            Bid bidToEdit = _repoBid.Get(id);
            return View(bidToEdit);
        }

        // POST: BidController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Bid bidToEdit = _repoBid.Get(id);
                bidToEdit.Rate = int.Parse(collection["Rate"]);
                _repoBid.Update(bidToEdit);
                return RedirectToAction("Index", "Car");
            }
            catch
            {
                return View();
            }
        }
    }
}
