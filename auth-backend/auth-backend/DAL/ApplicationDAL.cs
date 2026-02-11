using auth_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace auth_backend.DAL
{
    public class ApplicationDAL(AuthContext context)
    {
        private readonly AuthContext _context = context;
        public async Task<Application> GetApplicationByName(string applicationName)
        { 
            return await _context.Application.Where(a => a.Name == applicationName).FirstOrDefaultAsync();
        }
        public async Task<Application> GetById(int id)
        {
            return await _context.Application.Where(a => a.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<Application>> GetList()
        {
            
            return await _context.Application.ToListAsync();
        }
    }
}
