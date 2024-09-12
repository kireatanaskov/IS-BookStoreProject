using BookStore.Domain.Models;
using BookStore.Domain.Models.MusicApp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class DbContext1 : DbContext
    {
        public DbContext1(DbContextOptions<DbContext1> options) : base(options) 
        { 
            
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<UserPlaylist> UserPlaylists { get; set; }
        public virtual DbSet<TrackInPlaylist> TrackInPlaylists { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<TrackInOrder> TrackInOrders { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
    }
}
