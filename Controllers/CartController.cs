using Assignment5MusicShop.Data;
using Assignment5MusicShop.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace Assignment5MusicShop.Controllers
{
    public class CartController : Controller
    {
        private readonly Assignment5MusicShopContext _context;

        public CartController(Assignment5MusicShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        public IActionResult AddToCart(int id)
        {
            var music = _context.Music.FirstOrDefault(m => m.Id == id);
            if (music == null)
            {
                return NotFound();
            }

            var cart = GetCart();
            var existingItem = cart.Items.FirstOrDefault(i => i.MusicId == id);

            if (existingItem != null)
            {
                existingItem.Quantity += 1;
            }
            else
            {
                // Use the constructor directly
                var cartItem = new CartItem(music.Id, music.Title, music.Price, 1);
                cart.Items.Add(cartItem);
            }

            SaveCart(cart);
            return RedirectToAction("Index", "Musics");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var cart = GetCart();
            var itemToRemove = cart.Items.FirstOrDefault(i => i.MusicId == id);

            if (itemToRemove != null)
            {
                cart.Items.Remove(itemToRemove);
                SaveCart(cart);
            }

            return RedirectToAction("Index");
        }

        private Cart GetCart()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            return string.IsNullOrEmpty(cartJson) ? new Cart() : JsonConvert.DeserializeObject<Cart>(cartJson) ?? new Cart();
        }


        private void SaveCart(Cart cart)
        {
            var cartJson = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("Cart", cartJson);
        }
    }
}
