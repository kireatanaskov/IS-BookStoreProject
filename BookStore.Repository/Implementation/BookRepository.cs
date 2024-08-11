using BookStore.Domain.Models;
using BookStore.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext dbContext;
        private DbSet<Book> entities;

        public BookRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entities = dbContext.Set<Book>();
        }

        public Book Delete(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException("book");
            }

            this.entities.Remove(book);
            this.dbContext.SaveChanges();
            return book;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return this.entities
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .AsEnumerable();
        }

        public Book GetBookById(Guid? id)
        {
            return this.entities
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .First(e => e.Id == id);
        }

        public Book Insert(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException("book");
            }

            this.entities.Add(book);
            this.dbContext.SaveChanges();
            return book;
        }

        public Book Update(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException("book");
            }

            this.entities.Update(book);
            this.dbContext.SaveChanges();
            return book;
        }
    }
}
