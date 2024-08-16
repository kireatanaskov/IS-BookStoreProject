using BookStore.Domain.Identity;

namespace BookStore.Domain.Models
{
    public class ShoppingCart : BaseEntity
    {
        public string? OwnerId { get; set; }
        public BookStoreApplicationUser? Owner { get; set; }
        public virtual ICollection<BookInShoppingCart>? BookInShoppingCarts { get; set; }
    }
}
