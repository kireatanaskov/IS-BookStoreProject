using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Domain.Models;
using BookStore.Repository;
using BookStore.Service.Interface;
using System.Security.Claims;
using BookStore.Web.ViewModels;

namespace BookStore.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _publisherService;
        private readonly IShoppingCartService _shoppingCartService;

        public BooksController(IBookService bookService, IAuthorService authorService, IPublisherService publisherService, IShoppingCartService shoppingCartService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _publisherService = publisherService;
            _shoppingCartService = shoppingCartService;
        }

        private void PopulateDropdowns()
        {
            ViewData["AuthorId"] = new SelectList(_authorService.GetAllAuthors().Select(a => new { a.Id, FullName = a.FirstName + " " + a.LastName }), "Id", "FullName");
            ViewData["PublisherId"] = new SelectList(_publisherService.GetAllPublishers(), "Id", "Name");
        }


        public IActionResult Index()
        {
            return View(_bookService.GetAllBooks());
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null) 
                return NotFound();

            var book = _bookService.GetDetailsForBook(id);
            
            if (book == null) 
                return NotFound();

            return View(book);
        }

        public IActionResult Create()
        {
            PopulateDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Description,Image,Price,AuthorId,PublisherId,Id")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = Guid.NewGuid();
                book.Author = _authorService.GetAuthor(book.AuthorId);
                book.Publisher = _publisherService.GetPublisher(book.PublisherId);
                _bookService.CreateBook(book);
                return RedirectToAction(nameof(Index));
            }

            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            //foreach (var error in errors)
            //{
            //    Console.WriteLine(error);
            //}

            PopulateDropdowns();
            return View(book);
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var book = _bookService.GetDetailsForBook(id);
            if (book == null) return NotFound();

            PopulateDropdowns();
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,Description,Image,Price,AuthorId,PublisherId,Id")] Book book)
        {
            if (id != book.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _bookService.UpdateBook(book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            PopulateDropdowns();
            return View(book);
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var book = _bookService.GetDetailsForBook(id);
            if (book == null) return NotFound();

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _bookService.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddToCart(Guid? id)
        {
            if (id == null) return NotFound();

            var book = _bookService.GetDetailsForBook(id);

            BookInShoppingCart bs = new BookInShoppingCart();

            if (book != null)
            {
                bs.BookId = book.Id;
            }

            return View(bs);
        }

        [HttpPost]
        public IActionResult AddToCartConfirmed(BookInShoppingCart model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _shoppingCartService.AddToShoppingCartConfirmed(model, userId);

            return View("Index", _bookService.GetAllBooks());
        }
    }
}
