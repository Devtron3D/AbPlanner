using AbPlanner.DataAccess.Models;

namespace AbPlanner.DataAccess.Repositories
{
    public interface IAudiobookRepository
    {
        public Task<Audiobook?> GetAsync(int id);
        public Task<ICollection<Audiobook>> GetAllAsync();
        public Task<Audiobook> CreateAsync(Audiobook entity);
        public Task<Audiobook> UpdateAsync(Audiobook entity);
        public Task DeleteAsync(int id);
    }
}
