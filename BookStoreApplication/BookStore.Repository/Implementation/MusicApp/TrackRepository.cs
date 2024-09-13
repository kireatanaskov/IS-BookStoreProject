using BookStore.Domain.Models.MusicApp;
using BookStore.Repository.Interface.MusicApp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository.Implementation.MusicApp
{
    public class TrackRepository : ITrackRepository
    {
        private readonly DbContext1 dbContext;
        private readonly DbSet<Track> entities;

        public TrackRepository(DbContext1 dbContext)
        {
            this.dbContext = dbContext;
            this.entities = dbContext.Set<Track>();
        }

        public IEnumerable<Track> GetAllTracks()
        {
            return this.entities
                .Include(t => t.Album)
                .Include(t => t.Artist)
                .AsEnumerable();
        }
    }
}
