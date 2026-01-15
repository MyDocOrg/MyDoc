using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDoc.Infrastructure.AuthModels
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Rol { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<Suscription> Suscription { get; set; }
    }
}
