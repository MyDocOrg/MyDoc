using auth_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace auth_backend.DAL
{
    public class ApplicationDAL(AuthContext context)
    {
        private readonly AuthContext _context = context;
        public async Task<Application> GetApplicationByName(string applicationName)
        {
            try
            {
                return await _context.Application.Where(a => a.Name == applicationName).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong fetching application by name", ex);
            }
        }
    }
}
