using auth_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace auth_backend.DAL
{
    public class MyDocDAL(MyDocContext context)
    {
        private readonly MyDocContext _context = context; 
        public async Task<Doctor> AddDoctor(Doctor request)
        {
            try
            {
                await _context.Doctor.AddAsync(request);
                await _context.SaveChangesAsync();
                return request;
            }
            catch(Exception ex)
            {
                throw new Exception("something went wrong", ex);
            }
        }
        public async Task<Patient> AddPatient(Patient request)
        {
            try
            {
                await _context.Patient.AddAsync(request);
                await _context.SaveChangesAsync();
                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("something went wrong", ex);
            }
        }
        public async Task<Doctor> GetByIdDoctor(int id)
        {
            try
            {
                return await _context.Doctor.FirstOrDefaultAsync(d => d.id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("something went wrong", ex);
            }
        }
        public async Task<Patient> GetByIdPatient(int id)
        {
            try
            {
                return await _context.Patient.FirstOrDefaultAsync(p => p.id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("something went wrong", ex);
            }
        }
        public async Task<List<Doctor>> GetListDoctor(int id)
        {
            try
            {
                return await _context.Doctor.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("something went wrong", ex);
            }
        }
        public async Task<List<Patient>> GetListPatient()
        {
            try
            {
                return await _context.Patient.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("something went wrong", ex);
            }
        }
    }
}
