using BookStore.Domain.Models.MusicApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository.Interface.MusicApp
{
    public interface ITrackRepository
    {
        IEnumerable<Track> GetAllTracks();
    }
}
