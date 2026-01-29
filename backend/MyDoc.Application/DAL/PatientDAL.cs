using MyDoc.Application.DAL.Abstract;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.DAL
{
    public class PatientDAL : AbstractDAL<Patient>
    {
        private readonly ApplicationDbContext _context;

        public PatientDAL(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Patient>> GetAll()
        {
            var result = await base.GetAllAsync();
            return result.ToList();
        }

        public async Task<Patient?> GetById(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<Patient> Create(Patient entity)
        {
            await base.AddAsync(entity);
            return entity;
        }

        public async Task<Patient> Update(Patient entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await base.GetByIdAsync(id);
            if (entity == null)
            {
                return false;
            }
            //await base.DeleteAsync(entity);
            return true;
        }
    }
}
