using MyDoc.Application.DAL.Abstract;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.DAL
{
    public class PrescriptionDAL : AbstractDAL<Prescription>
    {
        private readonly ApplicationDbContext _context;

        public PrescriptionDAL(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Prescription>> GetAll()
        {
            var result = await base.GetAllAsync();
            return result.ToList();
        }

        public async Task<Prescription?> GetById(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<Prescription> Create(Prescription entity)
        {
            await base.AddAsync(entity);
            return entity;
        }

        public async Task<Prescription> Update(Prescription entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
