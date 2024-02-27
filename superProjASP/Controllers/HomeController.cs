using Microsoft.AspNetCore.Mvc;
using superProjASP.Data;
using superProjASP.Models;
using System.Data.Entity;
using System.Diagnostics;
using superProjASP.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace superProjASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly superProjASPContext _context;

        public HomeController(superProjASPContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.BookModel.ToList();
            return View(books);
        }
        public ActionResult Cart()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buy(int bookId)
        {
            //var book = _context.BookModel.FirstOrDefault(b => b.Id == bookId);
            //if (book != null)
            //{
            //    _context.BookModel.Remove(book);
            //    _context.SaveChanges();
            //}
            //return RedirectToAction(nameof(Cart));
            var book = _context.BookModel.FirstOrDefault(b => b.Id == bookId);
            if (book == null)
            {
                return NotFound();
            }
            _context.BookModel.Remove(book);

            _context.SaveChanges();
            return RedirectToAction(nameof(Cart));
        }

        [HttpPost]
        public IActionResult Search(string searchTerm)
        {
            var books = _context.BookModel
    .Where(b => EF.Functions.Like(b.Title, $"%{searchTerm}%") ||
                EF.Functions.Like(b.Author, $"%{searchTerm}%") ||
                b.YearOfPublication.Contains(searchTerm))
    .ToList();
            return View("Index", books);
        }
    }
}
