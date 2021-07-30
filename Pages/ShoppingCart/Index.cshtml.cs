using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SSDeShopOnWeb.Data;
using SSDeShopOnWeb.Models;
using SSDeShopOnWeb.ViewModels;

namespace SSDeShopOnWeb.Pages.ShoppingCart
{
    public class IndexModel : PageModel
    {
        private readonly StoreDbContext _db;

        public IndexModel(StoreDbContext db)
        {
            _db = db;
        }

        public Cart Cart { get; set; }
        public void OnGet()
        {
            Cart = _db.Carts
                .Include(c => c.CartProducts)
                .ThenInclude(cp => cp.Product)
                .Where(c => c.Id == (int)HttpContext.Session.GetInt32("cartId"))
                .FirstOrDefault();
        }
        public IActionResult OnPost(ProductVM testproduct)
        {
            if (testproduct?.Id == null)
            {
                return RedirectToPage("/Index");
            }

            //(need to validate against user or session)
            int? cartId = HttpContext.Session.GetInt32("cartId");
            //add new product to new cart
            Cart cart;
            if(cartId == null) //new cart
            {
                cart = new Cart(null);
                _db.Carts.Add(cart);
                _db.SaveChanges();
                cartId = cart.Id;
            }
            //update existing product in existing cart 
            CartProduct cp;
            //add new product to existing cart 
            cp = _db.CartProducts
                  .Where(cp => cp.CartId == cartId && cp.ProductId == testproduct.Id)
                  .FirstOrDefault();
            if (cp == null) //product not in this cart yet
            {
                cp = new CartProduct((int)cartId, testproduct.Id, testproduct.Price, testproduct.Quantity);
                _db.CartProducts.Add(cp);
               
            }
            else //product is already in cart
            {
                //might want to validate for price changes in the future
                cp.AddQuantity(testproduct.Quantity);
            }

            _db.SaveChanges();
            HttpContext.Session.SetInt32("cartId", (int)cartId);

            return RedirectToPage();
        }
    }
}
