using MyDoc.Application.DAL.Abstract;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.DAL
{
    public class MedicineDAL : AbstractDAL<Medicine>
    {
        private readonly ApplicationDbContext _context;

        public MedicineDAL(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Medicine>> GetAll()
        {
            var result = await base.GetAllAsync();
            return result.ToList();
        }

        public async Task<Medicine?> GetById(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<Medicine> Create(Medicine entity)
        {
            await base.AddAsync(entity);
            return entity;
        }

        public async Task<Medicine> Update(Medicine entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
