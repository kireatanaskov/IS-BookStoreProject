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

namespace BookStore.Web.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: Authors
        public IActionResult Index()
        {
            return View(_authorService.GetAllAuthors());
        }

        // GET: Authors/Details/1
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var author = _authorService.GetDetailsForAuthor(id);
            if (author == null) return NotFound();

            return View(author);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,Age,Country,Image,Id")] Author author)
        {
            if (ModelState.IsValid)
            {
                author.Id = Guid.NewGuid();
                _authorService.CreateAuthor(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Edit/1
        public IActionResult Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var product = _authorService.GetDetailsForAuthor(id);
            if (product == null) return NotFound();

            return View(product);
        }

        // POST: Authors/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("FirstName,LastName,Age,Country,Image,Id")] Author author)
        {
            if (id != author.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _authorService.UpdateAuthor(author);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Delete/1
        public IActionResult Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var author = _authorService.GetDetailsForAuthor(id);
            if (author == null) return NotFound();

            return View(author);
        }

        // POST: Authors/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _authorService.DeleteAuthor(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(Guid id)
        {
            return _authorService.GetAllAuthors()
                .Any(e => e.Id == id);
        }
    }
}
