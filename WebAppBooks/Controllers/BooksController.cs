using Microsoft.AspNetCore.Mvc;
using WebAppBooks.Models;

namespace WebAppBooks.Controllers
{
    public class BooksController : Controller
    {
        private static readonly List<Book> _books = new List<Book>();
        private static int _nextId = 1;

        // GET: /Books
        [HttpGet]
        public IActionResult Index()
        {
            return View(_books.OrderBy(b => b.Id).ToList());
        }

        // GET: /Books/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Book());
        }

        // POST: /Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Validate future date
            if (model.PublicationDate.HasValue && model.PublicationDate.Value.Date > DateTime.Today)
            {
                ModelState.AddModelError("", "Publication date cannot be in the future.");
                return View(model);
            }

            // Validate duplicate book (case-insensitive)
            if (_books.Any(b =>
                b.Title.Equals(model.Title, StringComparison.OrdinalIgnoreCase) &&
                b.Author.Equals(model.Author, StringComparison.OrdinalIgnoreCase)))
            {
                ModelState.AddModelError("", "A book with the same title and author already exists.");
                return View(model);
            }

            model.Id = _nextId++;
            _books.Add(model);
            TempData["ok"] = "Book was created successfully.";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Books/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();
            return View(book);
        }

        // POST: /Books/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book model)
        {
            var book = _books.FirstOrDefault(b => b.Id == model.Id);
            if (book == null) return NotFound();

            // Validate duplicate (case-insensitive, excluding current book)
            if (_books.Any(b =>
                b.Title.Equals(model.Title, StringComparison.OrdinalIgnoreCase) &&
                b.Author.Equals(model.Author, StringComparison.OrdinalIgnoreCase) &&
                b.Id != model.Id))
            {
                ModelState.AddModelError("", "Another book with the same title and author already exists.");
            }

            if (!ModelState.IsValid)
                return View(model);

            book.Title = model.Title;
            book.Author = model.Author;
            book.Isbn = model.Isbn;
            book.PublicationDate = model.PublicationDate;

            TempData["ok"] = "Book was updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Books/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();
            return View(book);
        }

        // POST: /Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();

            _books.Remove(book);
            TempData["ok"] = "Book was deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
