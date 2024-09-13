using BookStore.Domain.Models.MusicApp;
using BookStore.Repository.Interface.MusicApp;
using BookStore.Service.Interface.MusicApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Implementation.MusicApp
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;

        public TrackService(ITrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }

        public List<Track> GetAllTracks()
        {
            return _trackRepository.GetAllTracks().ToList();
        }
    }
}
