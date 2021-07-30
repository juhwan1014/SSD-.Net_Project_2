using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SSDeShopOnWeb.Data;
using SSDeShopOnWeb.Models;

namespace SSDeShopOnWeb.Pages.ShoppingCart
{
    public class _CartPatialModel : PageModel
    {
        private readonly SSDeShopOnWeb.Data.StoreDbContext _context;

        public _CartPatialModel(SSDeShopOnWeb.Data.StoreDbContext context)
        {
            _context = context;
        }

        public IList<CartProduct> CartProduct { get;set; }

        public async Task OnGetAsync()
        {
            CartProduct = await _context.CartProducts
                .Include(c => c.Cart)
                .Include(c => c.Product).ToListAsync();
        }
    }
}
