using MyDoc.Application.DAL.Abstract;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.DAL
{
    public class DoctorDAL : AbstractDAL<Doctor>
    {
        private readonly ApplicationDbContext _context;

        public DoctorDAL(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Doctor>> GetAll()
        {
            var result = await base.GetAllAsync();
            return result.ToList();
        }

        public async Task<Doctor?> GetById(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<Doctor> Create(Doctor entity)
        {
            await base.AddAsync(entity);
            return entity;
        }

        public async Task<Doctor> Update(Doctor entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
