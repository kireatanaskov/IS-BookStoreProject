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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext dbContext;
        private DbSet<Author> entities;

        public AuthorRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            entities = dbContext.Set<Author>();
        }

        public Author Delete(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException("author");
            }

            this.entities.Remove(author);
            this.dbContext.SaveChanges();
            return author;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return this.entities.AsEnumerable();
        }

        public Author GetAuthorById(Guid? id)
        {
            return this.entities.First(e => e.Id == id);
        }

        public Author Insert(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException("author");
            }

            this.entities.Add(author);
            this.dbContext.SaveChanges();
            return author;
        }

        public Author Update(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException("author");
            }

            this.entities.Update(author);
            this.dbContext.SaveChanges();
            return author;
        }
    }
}
