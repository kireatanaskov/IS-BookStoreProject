using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository.Interface
{
    public interface IBookRepository
    {
        Book GetBookById(Guid? id);
        IEnumerable<Book> GetAllBooks();
        Book Insert(Book book);
        Book Update(Book book);
        Book Delete(Book book);
    }
}
