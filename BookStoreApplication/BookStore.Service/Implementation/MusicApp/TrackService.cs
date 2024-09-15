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

        public List<Track> GetAllTransformedTracks()
        {
            var extractedTracks = _trackRepository.GetAllTracks().ToList();

            var transformedTracks = extractedTracks
                .Select(track => new Track
                {
                    Title = track.Title,
                    Duration = $"{track.Duration} ({GetSecondsFromDuration(track.Duration)} seconds)",
                    Image = track.Image,
                    AlbumId = track.AlbumId,
                    ArtistId = track.ArtistId,
                    Album = track.Album,
                    Artist = track.Artist,
                    Price = track.Price
                })
                .Where(track => track.Price > 0);

            return transformedTracks.ToList();
        }

        public string GetSecondsFromDuration(string time)
        {
            string[] splitTime = time.Split(':');
            int minutes = int.Parse(splitTime[0]);
            int seconds = int.Parse(splitTime[1]);

            seconds += minutes * 60;
            return seconds.ToString();
        }
    }
}
