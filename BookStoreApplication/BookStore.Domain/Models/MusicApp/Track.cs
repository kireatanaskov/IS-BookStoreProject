using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models.MusicApp
{
    public class Track : BaseEntity
    {
        public string? Title { get; set; }
        public string? Duration { get; set; }
        public string? Image { get; set; }
        public Guid AlbumId { get; set; }
        public Guid? ArtistId { get; set; }
        public Album? Album { get; set; }
        public Artist? Artist { get; set; }
        [Required]
        public double Price { get; set; }
        public ICollection<TrackInPlaylist>? TracksInPlaylist { get; set; }
        public virtual IEnumerable<TrackInOrder>? TrackInOrders { get; set; }
    }
}
