using auth_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace auth_backend.DAL
{
    public class RoleDAL
    {
        private readonly AuthContext _context;
        public RoleDAL(AuthContext context)
        {
            _context = context;
        }
        public async Task<Role> GetRoleByNameApplicationId(string roleName, int applicationId)
        {            
            return await _context.Role.Where(r => r.Name == roleName && r.ApplicationId == applicationId).FirstOrDefaultAsync();   
        }
        public async Task<List<Role>> GetByApplicationId(int applicationId)
        {
            return await _context.Role.Where(r => r.ApplicationId == applicationId).ToListAsync();
        }
        public async Task<Role> GetById(int id)
        {            
            return await _context.Role.Where(r => r.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<Role>> GetList()
        {
            return await _context.Role.ToListAsync();
        }
    }
}
