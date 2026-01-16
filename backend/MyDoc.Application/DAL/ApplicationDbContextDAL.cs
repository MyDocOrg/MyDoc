using MyDoc.Application.DAL.Abstract;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.DAL
{
    public class ApplicationDbContextDAL : AbstractDAL<ApplicationDbContext>
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextDAL(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ApplicationDbContext>> GetAll()
        {
            var result = await base.GetAllAsync();
            return result.ToList();
        }

        public async Task<ApplicationDbContext?> GetById(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<ApplicationDbContext> Create(ApplicationDbContext entity)
        {
            await base.AddAsync(entity);
            return entity;
        }

        public async Task<ApplicationDbContext> Update(ApplicationDbContext entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
