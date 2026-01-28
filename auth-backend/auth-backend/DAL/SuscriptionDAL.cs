using auth_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace auth_backend.DAL
{
    public class SuscriptionDAL
    {
        private readonly AuthContext _context;
        public SuscriptionDAL(AuthContext context)
        {
            _context = context;
        }
        public async Task<Suscription> GetById(int Id)
        {
            try
            {
                return await _context.Suscription.FirstOrDefaultAsync(s => s.Id == Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong fetching role by name", ex);
            }
        }
        public async Task<List<Suscription>> GetList()
        {
            try
            {
                return await _context.Suscription.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong fetching role by name", ex);
            }
        }
        public async Task<List<Suscription>> GetByApplicationId(int applicationId)
        {
            try
            {
                return await _context.Suscription.Where(r => r.ApplicationId == applicationId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong fetching role by name", ex);
            }
        }
    }
}
