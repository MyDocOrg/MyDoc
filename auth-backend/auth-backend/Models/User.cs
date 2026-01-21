using System;
using System.Collections.Generic;
using System.Text;

namespace auth_backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
        public int ApplicationId { get; set; }  
        public int SuscriptionId { get; set; }
    }
}
