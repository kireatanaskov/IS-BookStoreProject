using BookStore.Domain.DTO;
using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDto GetShoppingCartInfo(string userId);
        bool DeleteBookFromShoppingCart(string userId, Guid bookId);
        bool Order(string userId);
        bool AddToShoppingCartConfirmed(BookInShoppingCart model, string userId);
    }
}
