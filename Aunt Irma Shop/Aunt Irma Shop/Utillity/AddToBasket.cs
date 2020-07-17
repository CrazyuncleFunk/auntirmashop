using Aunt_Irma_Shop.Data;
using Aunt_Irma_Shop.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aunt_Irma_Shop.Utillity
{
    public class AddToBasket
    {

        public AddToBasket(Item item, int count, ApplicationDbContext db, HttpContext context, ClaimsIdentity claimIdentity)
        {


            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null)
            {
                if (context.Session.GetString("ssShoppingCart") == null)
                {
                    var cart = new List<TempCart>();
                    var cartObj = new TempCart()
                    {
                        Item = item,
                        ItemId = item.Id,
                        Count = count
                    };
                    cart.Add(cartObj);
                    context.Session.SetString("ssShoppingCart", JsonConvert.SerializeObject(cart));
                }
                else
                {
                    var cart = JsonConvert.DeserializeObject<List<TempCart>>("ssShoppingCart");
                    var cartObj = new TempCart()
                    {
                        Item = item,
                        ItemId = item.Id,
                        Count = count
                    };
                    cart.Add(cartObj);
                    context.Session.SetString("ssShoppingCart", JsonConvert.SerializeObject(cart));
                }

            }

            if (claim != null)
            {

                ShoppingCart cart = new ShoppingCart()
                {
                    Item = item,
                    ItemId = item.Id
                };
                cart.Id = 0;
                cart.ApplicationUserId = claim.Value;

                ShoppingCart cartDb = db.ShoppingCart.Where(c => c.ApplicationUserId == cart.ApplicationUserId
                                                                        && c.ItemId == cart.ItemId).FirstOrDefault();
                if (cartDb == null)
                {
                    db.ShoppingCart.Add(cart);
                }
                else
                {
                    cartDb.Count = cartDb.Count + cart.Count;
                }
                db.SaveChangesAsync();

                var Counter = db.ShoppingCart.Where(c => c.ApplicationUserId == cart.ApplicationUserId).ToList().Count();
                context.Session.SetInt32("ssCartCount", Counter);

            }
          


        }
    }
}
