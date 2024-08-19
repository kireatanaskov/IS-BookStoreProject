using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository.Interface
{
    public interface IAuthorRepository
    {
        Author GetAuthorById(Guid? id);
        IEnumerable<Author> GetAllAuthors();
        Author Insert(Author author);
        Author Update(Author author);
        Author Delete(Author author);
    }
}
