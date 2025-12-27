using Library.Common.Models;

namespace Library.Common.Services
{
    public class LabService
    {
        private readonly ThreadSafeRepository _repository;

        public LabService()
        {
            _repository = new ThreadSafeRepository();
        }

        public async Task CreateAsync(LabEntity item)
        {
            // Тут можна додати валідацію, якщо потрібно
            await _repository.AddAsync(item);
        }

        public async Task<LabEntity?> GetByIdAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IEnumerable<LabEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task UpdateAsync(int id, LabEntity item)
        {
            await _repository.UpdateAsync(id, item);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}