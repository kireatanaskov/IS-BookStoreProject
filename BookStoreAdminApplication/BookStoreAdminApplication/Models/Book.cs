using System.ComponentModel.DataAnnotations;

namespace BookStoreAdminApplication.Models
{
    public class Book
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Rating { get; set; }
    }
}
