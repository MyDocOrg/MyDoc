using auth_backend.DTO.User;
using auth_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace auth_backend.DAL
{
    public class AuthDAL
    {
        private readonly AuthContext _context;
        public AuthDAL(AuthContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User request)
        {
            try
            {
                await _context.AddAsync(request);
                await _context.SaveChangesAsync();
                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong creating user");
            }
        }

        public async Task<User> Login()
        {
            try
            {
                // Implementation for login
                return new User(); // Placeholder return
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong during login");
            }
        }
        public async Task<User> UserByEmail(string email)
        {
            try
            {
                return await _context.User.Where(u => u.Email == email).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong fetching user by email");
            }
        }
        public async Task<UserAuthDTO> UserPermissions(int userId)
        {
            try
            {
                return await (from user in _context.User
                              join rol in _context.Role on user.RoleId equals rol.Id
                              join sus in _context.Suscription on user.SuscriptionId equals sus.Id
                              join app in _context.Application on user.ApplicationId equals app.Id
                              where user.Id == userId
                              select new UserAuthDTO
                              {
                                  Id = user.Id,
                                  Email = user.Email,
                                  RoleId = rol.Id,
                                  RoleName = rol.Name,
                                  ApplicationId = app.Id,
                                  ApplicationName = app.Name,
                                  SuscriptionId = sus.Id,
                                  SuscriptionName = sus.Name
                              }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong fetching user by email", ex);
            }
        }
    }
}
