using BookStore.Domain.Models;
using BookStore.Domain.Models.MusicApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository.Interface
{
    public interface IArtistRepository
    {
        IEnumerable<Artist> GetAllArtists();
    }
}
