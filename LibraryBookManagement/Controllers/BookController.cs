using LibraryBookManagement.Facade;
using LibraryBookManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBookManagement.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private LibraryFacade _facade;

        public BookController(ILogger<HomeController> logger, LibraryFacade facade)
        {
            _logger = logger;
            _facade = facade;
        }


        // GET: BookController1
        public ActionResult Index(IFormCollection collection)
        {
            string query = collection["query"];
            if (query != null)
                return View(_facade.Search<Book>(query));

            var books = _facade.GetAll<Book>();
            return View(books);
        }

        // GET: BookController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Book book = new Book();
                book.Name = collection["Name"].ToString();
                book.Status = BookStatus.Available;
                book.ISBN = collection["ISBN"].ToString();
                book.Category = collection["Category"];
                book.YearPublished = int.Parse(collection["YearPublished"]);

                _facade.Insert(book);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: BookController1/Edit/5
        public ActionResult Edit(int id)
        {
            Book bookToEdit = _facade.Get<Book>(id);
            return View(bookToEdit);
        }

        // POST: BookController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Book bookToEdit = _facade.Get<Book>(id);
                bookToEdit.Name = collection["Name"].ToString();
                bookToEdit.Status = BookStatus.Available;
                bookToEdit.ISBN = collection["ISBN"].ToString();
                bookToEdit.Category = collection["Category"];
                bookToEdit.YearPublished = int.Parse(collection["YearPublished"]);
                _facade.Update(bookToEdit);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController1/Delete/5
        public ActionResult Delete(int id)
        {
            Book bookToDelete = _facade.Get<Book>(id);
            return View(bookToDelete);
        }

        // POST: BookController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Book bookToDelete = _facade.Get<Book>(id);
                _facade.Delete(bookToDelete);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
