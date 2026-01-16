using MyDoc.Application.DAL.Abstract;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.DAL
{
    public class AppointmentStatusDAL : AbstractDAL<AppointmentStatus>
    {
        private readonly ApplicationDbContext _context;

        public AppointmentStatusDAL(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<AppointmentStatus>> GetAll()
        {
            var result = await base.GetAllAsync();
            return result.ToList();
        }

        public async Task<AppointmentStatus?> GetById(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<AppointmentStatus> Create(AppointmentStatus entity)
        {
            await base.AddAsync(entity);
            return entity;
        }

        public async Task<AppointmentStatus> Update(AppointmentStatus entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
