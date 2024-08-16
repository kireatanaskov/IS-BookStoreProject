using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Domain.Models;
using BookStore.Repository;
using BookStore.Service.Interface;
using System.Security.Claims;
using Stripe;

namespace BookStore.Web.Controllers
{
    public class ShoppingCartsController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartsController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;
            return View(_shoppingCartService.GetShoppingCartInfo(userId ?? ""));
        }

        public IActionResult DeleteBookFromShoppingCart(Guid bookId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;
            var result = _shoppingCartService.DeleteBookFromShoppingCart(userId, bookId);

            return RedirectToAction("Index", "ShoppingCarts");
        }

        public Boolean OrderNow()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;
            var result = _shoppingCartService.Order(userId);

            return result;
        }

        public IActionResult PayOrder(string stripeEmail, string stripeToken)
        {
            var customerService = new CustomerService();
            var chargeService = new ChargeService();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            StripeConfiguration.ApiKey =
                "sk_test_51Io84IHBiOcGzrvu4sxX66rTHq8r5nxIxRiJPbOHB4NwVJOE1jSlxgYe741ITs024uXhtpBFtxm3RoCZc3kafocC00IhvgxkL0";

            var order = this._shoppingCartService.GetShoppingCartInfo(userId);

            var customer = customerService.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = chargeService.Create(new ChargeCreateOptions
            {
                Amount = (Convert.ToInt32(order.TotalPrice) * 100),
                Description = "Book Store Payment",
                Currency = "usd",
                Customer = customer.Id
            });

            if (charge.Status == "succeeded")
            {
                this.OrderNow();
                return RedirectToAction("SuccessPayment");

            }
            else
            {
                return RedirectToAction("NotsuccessPayment");
            }
        }

        public IActionResult SuccessPayment()
        {
            return View();
        }
    }
}
