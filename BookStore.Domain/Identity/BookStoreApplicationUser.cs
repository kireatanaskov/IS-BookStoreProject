﻿using BookStore.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Domain.Identity
{
    public class BookStoreApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual ICollection<Order>? Order { get; set; }
    }
}
