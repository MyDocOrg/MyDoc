using MyDoc.Application.DAL.Abstract;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.DAL
{
    public class PrescriptionMedicineDAL : AbstractDAL<PrescriptionMedicine>
    {
        private readonly ApplicationDbContext _context;

        public PrescriptionMedicineDAL(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<PrescriptionMedicine>> GetAll()
        {
            var result = await base.GetAllAsync();
            return result.ToList();
        }

        public async Task<PrescriptionMedicine?> GetById(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<PrescriptionMedicine> Create(PrescriptionMedicine entity)
        {
            await base.AddAsync(entity);
            return entity;
        }

        public async Task<PrescriptionMedicine> Update(PrescriptionMedicine entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
