using MyDoc.Application.DAL.Abstract;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.DAL
{
    public class ClinicDAL : AbstractDAL<Clinic>
    {
        private readonly ApplicationDbContext _context;

        public ClinicDAL(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Clinic>> GetAll()
        {
            var result = await base.GetAllAsync();
            return result.ToList();
        }

        public async Task<Clinic?> GetById(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<Clinic> Create(Clinic entity)
        {
            await base.AddAsync(entity);
            return entity;
        }

        public async Task<Clinic> Update(Clinic entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
