using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinalSystem.Generics
{
    public interface IGenericRepository<T>
    {
        T GetItem(int id);
        void AddItem(T model);
        void DeleteItem(int id);
        void UpdateItem(int? id, T model);
        IEnumerable<T> GetItems(Expression<Func<T, bool>> predicate = null);
    }
}
