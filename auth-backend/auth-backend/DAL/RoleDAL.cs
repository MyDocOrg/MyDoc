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
            try
            {
                return await _context.Role.Where(r => r.Name == roleName && r.ApplicationId == applicationId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong fetching role by name", ex);
            }
        }
        public async Task<List<Role>> GetByApplicationId(int applicationId)
        {
            try
            {
                return await _context.Role.Where(r => r.ApplicationId == applicationId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong fetching role by name", ex);
            }
        }
        public async Task<Role> GetById(int id)
        {
            try
            {
                return await _context.Role.Where(r => r.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong fetching role by name", ex);
            }
        }
        public async Task<List<Role>> GetList()
        {
            try
            {
                return await _context.Role.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong fetching role by name", ex);
            }
        }
    }
}
