using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSDeShopOnWeb.Models
{
    public class Cart : BaseEntity
    {
        public string BuyerId { get; private set; }
        //navigation properties
        public virtual ICollection<CartProduct> CartProducts { get; set; }
        public Cart(string buyerId)
        {
            BuyerId = buyerId;
        }
    }
}
