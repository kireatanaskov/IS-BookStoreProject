using BookStore.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers.MusicApp
{
    public class ArtistsController : Controller
    {
        private readonly IArtistService artistService;

        public ArtistsController(IArtistService artistService)
        {
            this.artistService = artistService;
        }

        public IActionResult Index()
        {
            return View(artistService.GetAllArtists());
        }
    }
}
