using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models.MusicApp
{
    public class Artist : BaseEntity
    {
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public DateTime? BirthDate { get; set; }
        public ICollection<Album>? Albums { get; set; }
        public ICollection<Track>? Tracks { get; set; }
    }
}
