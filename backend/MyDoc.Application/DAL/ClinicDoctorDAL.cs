using MyDoc.Application.DAL.Abstract;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.DAL
{
    public class ClinicDoctorDAL : AbstractDAL<ClinicDoctor>
    {
        private readonly ApplicationDbContext _context;

        public ClinicDoctorDAL(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ClinicDoctor>> GetAll()
        {
            var result = await base.GetAllAsync();
            return result.ToList();
        }

        public async Task<ClinicDoctor?> GetById(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<ClinicDoctor> Create(ClinicDoctor entity)
        {
            await base.AddAsync(entity);
            return entity;
        }

        public async Task<ClinicDoctor> Update(ClinicDoctor entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
