using Microsoft.EntityFrameworkCore;
using MyDoc.Models;

namespace MyDoc.UseCase.Abstract
{
    public class AbstractUseCase<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public AbstractUseCase(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        protected async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        protected async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        protected async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        protected void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        protected async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
