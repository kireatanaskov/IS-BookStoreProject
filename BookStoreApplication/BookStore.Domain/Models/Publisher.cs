namespace BookStore.Domain.Models
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
    }
}
