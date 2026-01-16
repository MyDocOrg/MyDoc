using MyDoc.Application.DAL.Abstract;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.DAL
{
    public class MedicalHistoryDAL : AbstractDAL<MedicalHistory>
    {
        private readonly ApplicationDbContext _context;

        public MedicalHistoryDAL(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<MedicalHistory>> GetAll()
        {
            var result = await base.GetAllAsync();
            return result.ToList();
        }

        public async Task<MedicalHistory?> GetById(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<MedicalHistory> Create(MedicalHistory entity)
        {
            await base.AddAsync(entity);
            return entity;
        }

        public async Task<MedicalHistory> Update(MedicalHistory entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
