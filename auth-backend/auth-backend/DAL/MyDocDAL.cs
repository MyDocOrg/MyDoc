using auth_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace auth_backend.DAL
{
    public class MyDocDAL(MyDocContext context)
    {
        private readonly MyDocContext _context = context; 
        public async Task<Doctor> AddDoctor(Doctor request)
        {
            await _context.Doctor.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }
        public async Task<Patient> AddPatient(Patient request)
        {
            await _context.Patient.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }
        public async Task<Doctor> GetByIdDoctor(int id)
        {
            return await _context.Doctor.FirstOrDefaultAsync(d => d.id == id);   
        }
        public async Task<Patient> GetByIdPatient(int id)
        {
            return await _context.Patient.FirstOrDefaultAsync(p => p.id == id);
        }
        public async Task<Doctor> GetByUserIdDoctor(int id)
        {
            return await _context.Doctor.FirstOrDefaultAsync(d => d.user_id == id);
        }
        public async Task<Patient> GetByUserIdPatient(int id)
        {
            return await _context.Patient.FirstOrDefaultAsync(p => p.user_id == id);
        }
        public async Task<List<Doctor>> GetListDoctor(int id)
        {            
            return await _context.Doctor.ToListAsync();
        }
        public async Task<List<Patient>> GetListPatient()
        {
            return await _context.Patient.ToListAsync();
        }
    }
}
