using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalSystem.Models
{
    public class DeleteSearchFilterModel
    {
        public List<ProductModel> ProductModels { get; set; }
        public List<ProductCategoryModel> ProductCategoryModels { get; set; }
        public ProductModel Product { get; set; }
        public bool IsFiltered { get; set; }
    }
}
