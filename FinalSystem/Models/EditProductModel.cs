using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalSystem.Models
{
    public class EditProductModel
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int ProductCategoryId { get; set; }
        public IEnumerable<ProductCategoryModel> categories { get; set; }
        public IEnumerable<ProductModel> productModels { get; set; }
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
