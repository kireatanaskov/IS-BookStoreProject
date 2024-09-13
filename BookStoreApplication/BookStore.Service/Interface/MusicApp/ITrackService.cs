using BookStore.Domain.Models.MusicApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Interface.MusicApp
{
    public interface ITrackService
    {
        List<Track> GetAllTracks();
    }
}
