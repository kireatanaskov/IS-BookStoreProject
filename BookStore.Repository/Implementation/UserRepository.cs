using BookStore.Domain.Identity;
using BookStore.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;
        private DbSet<BookStoreApplicationUser> users;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            users = dbContext.Set<BookStoreApplicationUser>();
        }

        public IEnumerable<BookStoreApplicationUser> GetAll()
        {
            return this.users.AsEnumerable();
        }

        public BookStoreApplicationUser Get(string id)
        {
            return this.users
                .Include(z => z.ShoppingCart)
                .Include("ShoppingCart.BookInShoppingCarts")
                .Include("ShoppingCart.BookInShoppingCarts.Book")
                .First(user => user.Id == id);
        }

        public void Delete(BookStoreApplicationUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            this.users.Remove(user);
            this.dbContext.SaveChanges();
        }

        public void Insert(BookStoreApplicationUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            this.users.Add(user);
            this.dbContext.SaveChanges();
        }

        public void Update(BookStoreApplicationUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            this.users.Update(user);
            this.dbContext.SaveChanges();
        }
    }
}
