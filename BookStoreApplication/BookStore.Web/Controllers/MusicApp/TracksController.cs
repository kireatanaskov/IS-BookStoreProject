using BookStore.Service.Interface.MusicApp;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers.MusicApp
{
    public class TracksController : Controller
    {
        private readonly ITrackService _trackService;

        public TracksController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        public IActionResult Index()
        {
            return View(_trackService.GetAllTransformedTracks());
        }
    }
}
