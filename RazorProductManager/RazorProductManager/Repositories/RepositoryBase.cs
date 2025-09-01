using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorProductManager.Data;
using RazorProductManager.Interfaces;

namespace RazorProductManager.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected List<T> _store;

        public RepositoryBase(List<T> initialStore)
        {
            _store = initialStore;
        }

        public Task<IEnumerable<T>> GetAllAsync() => Task.FromResult<IEnumerable<T>>(_store);

        public Task<T> GetByIdAsync(int id)
        {
            var prop = typeof(T).GetProperty("Id");
            var match = _store.FirstOrDefault(x => (int)prop.GetValue(x) == id);
            return Task.FromResult(match);
        }

        public Task AddAsync(T entity)
        {
            _store.Add(entity);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(T entity)
        {
            var prop = typeof(T).GetProperty("Id");
            int id = (int)prop.GetValue(entity);

            var old = _store.FirstOrDefault(x => (int)prop.GetValue(x) == id);
            if (old != null)
            {
                _store.Remove(old);
                _store.Add(entity);
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var prop = typeof(T).GetProperty("Id");
            var entity = _store.FirstOrDefault(x => (int)prop.GetValue(x) == id);
            if (entity != null)
                _store.Remove(entity);

            return Task.CompletedTask;
        }
    }
}
