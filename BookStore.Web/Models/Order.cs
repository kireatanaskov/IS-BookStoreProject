namespace BookStore.Web.Models
{
    public class Order : BaseEntity
    {
        public string userId { get; set; }
        public BookStoreApplicationUser Owner { get; set; }
        public IEnumerable<BookInOrder> BooksInOrder { get; set; }
    }
}
