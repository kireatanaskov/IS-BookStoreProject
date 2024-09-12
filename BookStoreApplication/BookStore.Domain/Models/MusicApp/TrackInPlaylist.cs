using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models.MusicApp
{
    public class TrackInPlaylist : BaseEntity
    {
        public Guid TrackId { get; set; }

        public Guid UserPlaylistId { get; set; }

        public Track? Track { get; set; }

        public UserPlaylist? Playlist { get; set; }
        //public DateTime AddedAt { get; set; }
        public int Quantity { get; set; }
    }
}
