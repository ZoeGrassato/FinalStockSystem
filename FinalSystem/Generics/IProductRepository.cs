using FinalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalSystem.Generics
{
    public interface IProductRepository : IGenericRepository<ProductModel>
    {
    }
}
