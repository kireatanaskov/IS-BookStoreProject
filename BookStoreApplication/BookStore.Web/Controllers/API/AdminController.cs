using BookStore.Domain.Identity;
using BookStore.Domain.Models;
using BookStore.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IAuthorService _authorService;
        private readonly UserManager<BookStoreApplicationUser> _userManager;

        public AdminController(IOrderService orderService, IAuthorService authorService, UserManager<BookStoreApplicationUser> userManager)
        {
            _orderService = orderService;
            _authorService = authorService;
            _userManager = userManager;
        }

        [HttpGet("[action]")]
        public List<Order> GetAllOrders()
        {
            return this._orderService.GetAllOrders();
        }

        [HttpPost("[action]")]
        public Order GetDetails(BaseEntity id)
        {
            return this._orderService.GetDetailsForOrder(id);
        }

        [HttpPost("[action]")]
        public void ImportAuthors(List<Author> model)
        {
            foreach (var item in model)
            {
                var author = new Author
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Age = item.Age,
                    Country = item.Country,
                    Image = item.Image
                };

                _authorService.CreateAuthor(author);
            }
        }
    }
}
