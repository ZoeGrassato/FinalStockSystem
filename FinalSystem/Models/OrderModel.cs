using FinalSystem.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalSystem.Models
{
    public class OrderModel : BaseItem
    {
        public ProductModel Product { get; set; }
        public string ShopId { get; set; }
    }
}
