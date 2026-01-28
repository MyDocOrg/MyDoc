using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace auth_backend.Models
{
    public partial class MyDocContext : DbContext
    {
        public MyDocContext(DbContextOptions<MyDocContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Doctor> Doctor { get; set; }

        public virtual DbSet<Patient> Patient { get; set; }
    }
}
