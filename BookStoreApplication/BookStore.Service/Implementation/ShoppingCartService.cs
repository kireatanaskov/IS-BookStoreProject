using BookStore.Domain.DTO;
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
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<BookInShoppingCart> _bookInShoppingCartRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<BookInOrder> _bookInOrderRepository;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository, IRepository<BookInShoppingCart> bookInShoppingCartRepository, IUserRepository userRepository, IRepository<Order> orderRepository, IRepository<BookInOrder> bookInOrderRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _bookInShoppingCartRepository = bookInShoppingCartRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _bookInOrderRepository = bookInOrderRepository;
        }

        public bool AddToShoppingCartConfirmed(BookInShoppingCart model, string userId)
        {
            var loggedInUser = _userRepository.Get(userId);
            var userShoppingCart = loggedInUser.ShoppingCart;

            if (userShoppingCart.BookInShoppingCarts == null)
                userShoppingCart.BookInShoppingCarts = new List<BookInShoppingCart>(); ;

            userShoppingCart.BookInShoppingCarts.Add(model);
            _shoppingCartRepository.Update(userShoppingCart);
            return true;
        }

        public bool DeleteBookFromShoppingCart(string userId, Guid bookId)
        {
            if (bookId == null) return false;

            var loggedInUser = _userRepository.Get(userId);
            var userShoppingCart = loggedInUser.ShoppingCart;
            var book = userShoppingCart.BookInShoppingCarts
                .Where(x => x.BookId == bookId)
                .FirstOrDefault();

            userShoppingCart.BookInShoppingCarts.Remove(book);
            _shoppingCartRepository.Update(userShoppingCart);
            return true;
        }

        public ShoppingCartDto GetShoppingCartInfo(string userId)
        {
            var loggedInUser = _userRepository.Get(userId);
            var userShoppingCart = loggedInUser?.ShoppingCart;
            var booksInShoppingCart = userShoppingCart?.BookInShoppingCarts?.ToList();
            var totalPrice = booksInShoppingCart
                .Select(x => (x.Book.Price * x.Quantity))
                .Sum();

            ShoppingCartDto dto = new ShoppingCartDto
            {
                Books = booksInShoppingCart,
                TotalPrice = totalPrice
            };
            return dto;
        }

        public bool Order(string userId)
        {
            if (userId == null) return false;

            var loggedInUser = _userRepository.Get(userId);
            var userShoppingCart = loggedInUser.ShoppingCart;

            Order order = new Order
            {
                Id = Guid.NewGuid(),
                userId = userId,
                Owner = loggedInUser
            };

            _orderRepository.Insert(order);

            List<BookInOrder> bookInOrder = new List<BookInOrder>();

            var list = userShoppingCart.BookInShoppingCarts.Select(
                x => new BookInOrder
                {
                    Id = Guid.NewGuid(),
                    BookId = x.Book.Id,
                    Book = x.Book,
                    OrderId = order.Id,
                    Order = order,
                    Quantity = x.Quantity
                }
                ).ToList();

            bookInOrder.AddRange(list);

            foreach (var book in bookInOrder)
            {
                _bookInOrderRepository.Insert(book);
            }

            loggedInUser.ShoppingCart.BookInShoppingCarts.Clear();
            _userRepository.Update(loggedInUser);
            return true;
        }
    }
}
