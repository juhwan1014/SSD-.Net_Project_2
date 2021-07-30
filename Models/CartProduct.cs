using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSDeShopOnWeb.Models
{
    public class CartProduct
    {
        [Key, Column(Order = 0)]
        public int CartId { get; private set; }
        [Key, Column(Order = 1)]
        public int ProductId { get; private set; }
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        //navigation properties
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }

        public CartProduct(int cartId, int productId, decimal unitPrice, int quantity )
        {
            CartId = cartId;
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }
    }
}
