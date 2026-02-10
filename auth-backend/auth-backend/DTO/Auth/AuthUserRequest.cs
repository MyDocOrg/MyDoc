using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace auth_backend.DTO.Auth
{
    public class AuthUserRequest
    {
        public string Email { get; set; } = null!;
        
        public string Password { get; set; } = null!;

        public DateOnly? birth_date { get; set; }

        [StringLength(1)]
        [Unicode(false)]
        public string? gender { get; set; }

        [StringLength(200)]
        [Unicode(false)]
        public string? address { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        public string? full_name { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        public string? specialty { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string? professional_license { get; set; }

        [StringLength(20)]
        [Unicode(false)]
        public string? phone { get; set; }

        public bool? is_active { get; set; }

        public int RoleId { get; set; }

        public int ApplicationId { get; set; }

        public int SuscriptionId { get; set; }
    }
}
