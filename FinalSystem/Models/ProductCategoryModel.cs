using FinalSystem.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalSystem.Models
{
    public class ProductCategoryModel : BaseItem
    {
        public string CategoryName { get; set; }
        public Guid ShopId { get; set; }
    }
}
