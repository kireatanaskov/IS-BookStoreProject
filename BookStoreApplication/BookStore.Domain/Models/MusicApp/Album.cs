using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models.MusicApp
{
    public class Album : BaseEntity
    {
        public string? Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid ArtistId { get; set; }

        public Artist? Artist { get; set; }
        public ICollection<Track>? Tracks { get; set; }
    }
}
