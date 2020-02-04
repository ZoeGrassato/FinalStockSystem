using FinalSystem.Base;
using FinalSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinalSystem.Repositories
{
    public abstract class GenericRepository<T> : Generics.IGenericRepository<T> where T : BaseItem
    {
        internal readonly ApplicationDbContext _applicationDbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _applicationDbContext = dbContext;
        }

        public void AddItem(T model)
        {
            var currentDbSet = _applicationDbContext.Set<T>();
            currentDbSet.Add(model);

        }

        public void DeleteItem(int id)
        {
            var currentDbSet = _applicationDbContext.Set<T>();
            currentDbSet.Remove(currentDbSet.FirstOrDefault(x => x.Id == id));
        }

        public T GetItem(int id)
        {
            var currentDbSet = _applicationDbContext.Set<T>();
            return currentDbSet.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetItems(Expression<Func<T, bool>> predicate = null)
        {
            var currentDbSet = _applicationDbContext.Set<T>();

            return predicate == null
                ? currentDbSet.AsEnumerable()
                : currentDbSet.Where(predicate).AsEnumerable();
        }

        public void UpdateItem(int? id, T model)
        {
            var currentDbSet = _applicationDbContext.Set<T>();
            currentDbSet.Update(model);
        }
    }
}
