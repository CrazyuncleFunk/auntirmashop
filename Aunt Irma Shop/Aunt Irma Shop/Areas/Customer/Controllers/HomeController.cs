using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aunt_Irma_Shop.Models;
using Aunt_Irma_Shop.Models.ViewModels;
using Aunt_Irma_Shop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Aunt_Irma_Shop.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db, ILogger<HomeController> logger)
        {
            _db = db;
            _logger = logger;
        }
      

        public async Task<IActionResult> Index()
        {
            IndexViewModel indexVM = new IndexViewModel
            {
                Category = await _db.Category.ToListAsync(),
                SubCategory = await _db.SubCategory.ToListAsync(),
                Item = await _db.Item.Include(i => i.Category).Include(i => i.SubCategory).ToListAsync()
            };
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
          
            if(claim == null && HttpContext.Session.GetString("ssShoppingCart") == null)
            {
                var cart = new List<ShoppingCart>();
                HttpContext.Session.SetString("ssShoppingCart", JsonConvert.SerializeObject(cart));
            }

            if (claim != null)
            {
                var count = _db.ShoppingCart.Where(u => u.ApplicationUserId == claim.Value).ToList().Count();
                HttpContext.Session.SetInt32("ssCartCount", count);
            }

            return View(indexVM);
        }
        public IActionResult AddToBasket(Item item,int count)
        {
            
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null)
            {
                if (HttpContext.Session.GetString("ssShoppingCart") == null)
                {
                    var cart = new List<ShoppingCart>();
                    var cartObj = new ShoppingCart()
                    {
                        Item = item,
                        ItemId = item.Id
                    };
                    cart.Add(cartObj);
                    HttpContext.Session.SetString("ssShoppingCart", JsonConvert.SerializeObject(cart));
                }
                else
                {
                    var cart = JsonConvert.DeserializeObject<List<ShoppingCart>>("ssShoppingCart");
                    var cartObj = new ShoppingCart()
                    {
                        Item = item,
                        ItemId = item.Id
                    };
                    cart.Add(cartObj);
                    HttpContext.Session.SetString("ssShoppingCart", JsonConvert.SerializeObject(cart));
                }
               
            }

            if (claim != null)
            {
                var cartCount = _db.ShoppingCart.Where(u => u.ApplicationUserId == claim.Value).ToList().Count();
                HttpContext.Session.SetInt32("ssCartCount", cartCount);
            }
            else
            {
                HttpContext.Session.SetInt32("ssCartCount", cartCount);
            }

            
        }
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Item item = await _db.Item.Include(s => s.Category).Include(s => s.SubCategory).FirstOrDefaultAsync(i => i.Id == id);
            if(item == null)
            {
                return NotFound();
            }
            ShoppingCart cartObj = new ShoppingCart()
            {
                Item = item,
                ItemId = item.Id
            };
            return View(cartObj);
        }
        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Details(ShoppingCart cart)
        {
            cart.Id = 0;
            if (ModelState.IsValid)
            {
                var claimsId = (ClaimsIdentity)this.User.Identity;
                var claim = claimsId.FindFirst(ClaimTypes.NameIdentifier);
                cart.ApplicationUserId = claim.Value;

                ShoppingCart cartDb = await _db.ShoppingCart.Where(c => c.ApplicationUserId == cart.ApplicationUserId 
                                                                        && c.ItemId == cart.ItemId).FirstOrDefaultAsync();
                if(cartDb == null)
                {
                    await _db.ShoppingCart.AddAsync(cart);
                }
                else
                {
                    cartDb.Count = cartDb.Count + cart.Count;
                }
                await _db.SaveChangesAsync();

                var count = _db.ShoppingCart.Where(c => c.ApplicationUserId == cart.ApplicationUserId).ToList().Count();
                HttpContext.Session.SetInt32("ssCartCount", count);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                Item item = await _db.Item.Include(s => s.Category).Include(s => s.SubCategory).FirstOrDefaultAsync(i => i.Id == cart.ItemId);
               
                ShoppingCart cartObj = new ShoppingCart()
                {
                    Item = item,
                    ItemId = item.Id
                };

                return View(cartObj);
            }
            
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
