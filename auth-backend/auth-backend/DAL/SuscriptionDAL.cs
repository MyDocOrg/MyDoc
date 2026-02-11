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
            
            return await _context.Suscription.FirstOrDefaultAsync(s => s.Id == Id);
            
        }
        public async Task<List<Suscription>> GetList()
        {
            
            return await _context.Suscription.ToListAsync();
            
        }
        public async Task<List<Suscription>> GetByApplicationId(int applicationId)
        {
            return await _context.Suscription.Where(r => r.ApplicationId == applicationId).ToListAsync();
        }
    }
}
