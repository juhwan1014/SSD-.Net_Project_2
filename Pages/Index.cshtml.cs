using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SSDeShopOnWeb.Data;
using SSDeShopOnWeb.ViewModels;

namespace SSDeShopOnWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly StoreDbContext _db;

        public IndexModel(StoreDbContext db)
        {
            _db = db;
        }

        public List<ProductVM> Products = new List<ProductVM>();

        public async Task OnGet()
        {
            Products = await _db.Products.Select(p => new ProductVM { 
            Id = p.Id, 
            Name = p.Name,
            Price = p.Price,
            PictureUri = p.PictureUri,
            Quantity = 1
            }).ToListAsync();
        }
    }
}
