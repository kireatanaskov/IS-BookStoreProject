﻿using BookStore.Domain.Models;
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
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<BookInShoppingCart> _bookInShoppingCartRepository;
        private readonly IUserRepository _userRepository;

        public BookService(IRepository<Book> bookRepository, IRepository<BookInShoppingCart> bookInShoppingCartRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _bookInShoppingCartRepository = bookInShoppingCartRepository;
            _userRepository = userRepository;
        }

        public void CreateBook(Book b)
        {
            _bookRepository.Insert(b);
        }

        public void DeleteBook(Guid? id)
        {
            var book = _bookRepository.Get(id);
            _bookRepository.Delete(book);
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll().ToList();
        }

        public Book GetDetailsForBook(Guid? id)
        {
            var book = _bookRepository.Get(id);
            return book;
        }

        public void UpdateBook(Book b)
        {
            _bookRepository.Update(b);
        }
    }
}
