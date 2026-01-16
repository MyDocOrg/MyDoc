using MyDoc.Application.DAL.Abstract;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.DAL
{
    public class MedicationScheduleDAL : AbstractDAL<MedicationSchedule>
    {
        private readonly ApplicationDbContext _context;

        public MedicationScheduleDAL(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<MedicationSchedule>> GetAll()
        {
            var result = await base.GetAllAsync();
            return result.ToList();
        }

        public async Task<MedicationSchedule?> GetById(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<MedicationSchedule> Create(MedicationSchedule entity)
        {
            await base.AddAsync(entity);
            return entity;
        }

        public async Task<MedicationSchedule> Update(MedicationSchedule entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
