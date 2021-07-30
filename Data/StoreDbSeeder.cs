﻿using Microsoft.EntityFrameworkCore;
using SSDeShopOnWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSDeShopOnWeb.Data
{
    public class StoreDbSeeder
    {
        public static async Task SeedAsync(StoreDbContext storeContext)
        {
            if (!await storeContext.Products.AnyAsync())
            {
                await storeContext.Products.AddRangeAsync(
                    GetPreconfiguredItems());

                await storeContext.SaveChangesAsync();
            }
        }

        static IEnumerable<Product> GetPreconfiguredItems()
        {
            return new List<Product>()
            {
                new Product(".NET Bot Black Sweatshirt", ".NET Bot Black Sweatshirt", 19.5m,  "/images/products/1.png"),
                new Product(".NET Black & White Mug", ".NET Black & White Mug", 8.50m, "/images/products/2.png"),
                new Product("Prism White T-Shirt", "Prism White T-Shirt", 12m,  "/images/products/3.png"),
                new Product(".NET Foundation Sweatshirt", ".NET Foundation Sweatshirt", 12m, "/images/products/4.png"),
                new Product("Roslyn Red Sheet", "Roslyn Red Sheet", 8.5m, "/images/products/5.png"),
                new Product(".NET Blue Sweatshirt", ".NET Blue Sweatshirt", 12m, "/images/products/6.png"),
                new Product("Roslyn Red T-Shirt", "Roslyn Red T-Shirt",  12m, "/images/products/7.png"),
                new Product("Kudu Purple Sweatshirt", "Kudu Purple Sweatshirt", 8.5m, "/images/products/8.png"),
                new Product("Cup<T> White Mug", "Cup<T> White Mug", 12m, "/images/products/9.png"),
                new Product(".NET Foundation Sheet", ".NET Foundation Sheet", 12m, "/images/products/10.png"),
                new Product("Cup<T> Sheet", "Cup<T> Sheet", 8.5m, "/images/products/11.png"),
                new Product("Prism White TShirt", "Prism White TShirt", 12m, "/images/products/12.png")
            };
        }
    }
}
