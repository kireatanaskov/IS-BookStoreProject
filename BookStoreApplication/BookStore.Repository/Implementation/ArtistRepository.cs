using BookStore.Domain.Models;
using BookStore.Domain.Models.MusicApp;
using BookStore.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository.Implementation
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly DbContext1 dbContext;
        private DbSet<Artist> entities;

        public ArtistRepository(DbContext1 dbContext)
        {
            this.dbContext = dbContext;
            entities = dbContext.Set<Artist>();
        }

        public IEnumerable<Artist> GetAllArtists()
        {
            return entities.AsEnumerable();
        }
    }
}
