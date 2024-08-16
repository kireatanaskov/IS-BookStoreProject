using BookStore.Domain.Models;
using BookStore.Repository.Interface;
using BookStore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Implementation
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void CreateBook(Book b)
        {
            this._bookRepository.Insert(b);
        }

        public void DeleteBook(Guid? id)
        {
            var book = _bookRepository.GetBookById(id);
            _bookRepository.Delete(book);
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks().ToList();
        }

        public Book GetDetailsForBook(Guid? id)
        {
            var book = _bookRepository.GetBookById(id);
            return book;
        }

        public void UpdateBook(Book b)
        {
            _bookRepository.Update(b);
        }
    }
}
