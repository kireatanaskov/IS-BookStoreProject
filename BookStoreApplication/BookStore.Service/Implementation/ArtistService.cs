using BookStore.Domain.Models.MusicApp;
using BookStore.Repository.Interface;
using BookStore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Implementation
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            this.artistRepository = artistRepository;
        }

        public List<Artist> GetAllArtists()
        {
            return this.artistRepository.GetAllArtists().ToList();
        }
    }
}
