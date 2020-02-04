using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalSystem.Generics
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductCategoryRepository ProductCategoryRepository { get; }
        void Save();
    }
}
