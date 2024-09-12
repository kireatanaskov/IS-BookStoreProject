using BookStore.Domain.Models;
using BookStore.Domain.Models.MusicApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Interface
{
    public interface IArtistService
    {
        List<Artist> GetAllArtists();
    }
}
