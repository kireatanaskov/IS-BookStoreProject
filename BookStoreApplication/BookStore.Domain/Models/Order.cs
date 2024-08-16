using BookStore.Domain.Identity;

namespace BookStore.Domain.Models
{
    public class Order : BaseEntity
    {
        public string userId { get; set; }
        public IEnumerable<BookInOrder> BooksInOrder { get; set; }
    }
}
