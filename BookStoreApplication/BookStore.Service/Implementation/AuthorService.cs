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
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public void CreateAuthor(Author author)
        {
            this._authorRepository.Insert(author);
        }

        public void DeleteAuthor(Guid? id)
        {
            Author author = this._authorRepository.GetAuthorById(id);
            this._authorRepository.Delete(author);
        }

        public List<Author> GetAllAuthors()
        {
            return this._authorRepository.GetAllAuthors().ToList();
        }

        public Author GetAuthor(Guid? id)
        {
            return this._authorRepository.GetAuthorById(id);
        }

        public void UpdateAuthor(Author author)
        {
            this._authorRepository.Update(author);
        }
    }
}
