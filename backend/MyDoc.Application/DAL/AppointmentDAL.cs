using MyDoc.Application.DAL.Abstract;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.DAL
{
    public class AppointmentDAL : AbstractDAL<Appointment>
    {
        private readonly ApplicationDbContext _context;

        public AppointmentDAL(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Appointment>> GetAll()
        {
            var result = await base.GetAllAsync();
            return result.ToList();
        }

        public async Task<Appointment?> GetById(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<Appointment> Create(Appointment entity)
        {
            await base.AddAsync(entity);
            return entity;
        }

        public async Task<Appointment> Update(Appointment entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
