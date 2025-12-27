using System.Collections.Concurrent;
using Library.Common.Models;

namespace Library.Common.Services
{
    public class ThreadSafeRepository
    {
        // Потокобезпечний словник для зберігання даних
        private readonly ConcurrentDictionary<int, LabEntity> _storage = new();

        public Task AddAsync(LabEntity item)
        {
            return Task.Run(() =>
            {
                _storage.TryAdd(item.Id, item);
            });
        }

        public Task<LabEntity?> GetAsync(int id)
        {
            return Task.Run(() =>
            {
                _storage.TryGetValue(id, out var item);
                return item;
            });
        }

        public Task<IEnumerable<LabEntity>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                return (IEnumerable<LabEntity>)_storage.Values.ToList();
            });
        }

        public Task UpdateAsync(int id, LabEntity newItem)
        {
            return Task.Run(() =>
            {
                if (_storage.ContainsKey(id))
                {
                    _storage[id] = newItem;
                }
            });
        }

        public Task DeleteAsync(int id)
        {
            return Task.Run(() =>
            {
                _storage.TryRemove(id, out _);
            });
        }
    }
}