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
using BookStore.Service.Implementation;

namespace BookStore.Web.Controllers
{
    public class PublishersController : Controller
    {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        // GET: Publishers
        public IActionResult Index()
        {
            return View(_publisherService.GetAllPublishers());
        }

        // GET: Publishers/Details/1
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var publisher = _publisherService.GetDetailsForPublisher(id);
            if (publisher == null) return NotFound();

            return View(publisher);
        }

        // GET: Publishers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publishers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Country,Address,Id")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                publisher.Id = Guid.NewGuid();
                _publisherService.CreatePublisher(publisher);
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        // GET: Publishers/Edit/1
        public IActionResult Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var publisher = _publisherService.GetDetailsForPublisher(id);
            if (publisher == null) return NotFound();

            return View(publisher);
        }

        // POST: Publishers/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,Country,Address,Id")] Publisher publisher)
        {
            if (id != publisher.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _publisherService.UpdatePublisher(publisher);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        // GET: Publishers/Delete/1
        public IActionResult Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var publisher = _publisherService.GetDetailsForPublisher(id);
            if (publisher == null) return NotFound();

            return View(publisher);
        }

        // POST: Publishers/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _publisherService.DeletePublisher(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PublisherExists(Guid id)
        {
            return _publisherService.GetAllPublishers()
                .Any(e => e.Id == id);
        }
    }
}
