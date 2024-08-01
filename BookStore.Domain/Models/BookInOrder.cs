namespace BookStore.Domain.Models
{
    public class BookInOrder : BaseEntity
    {
        public Guid BookId { get; set; }
        public Book Product { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
    }
}
