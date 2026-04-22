

using AbPlanner.DataAccess.Data;
using AbPlanner.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AbPlanner.DataAccess.Repositories
{
    public class AudiobookRepository(AbPlannerContext context) : IAudiobookRepository
    {
        public async Task<Audiobook?> GetAsync(int id)
        {
            return await context.Audiobooks
                .Include(a => a.Authors)
                .Include(a => a.Genres)
                .Include(a => a.Languages)
                .Include(a => a.Narrators)
                .Include(a => a.Publisher)
                .Include(a => a.Ratings)
                .Include(a => a.Series)
                .Include(a => a.Tags)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<ICollection<Audiobook>> GetAllAsync()
        {
            return await context.Audiobooks
                .Include(a => a.Authors)
                .Include(a => a.Genres)
                .Include(a => a.Languages)
                .Include(a => a.Narrators)
                .Include(a => a.Publisher)
                .Include(a => a.Ratings)
                .Include(a => a.Series)
                .Include(a => a.Tags)
                .ToListAsync();
        }
        public async Task<Audiobook> CreateAsync(Audiobook entity)
        {
            await context.Audiobooks.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<Audiobook> UpdateAsync(Audiobook entity)
        {
            context.Audiobooks.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            await context.Audiobooks
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }

    }
}
