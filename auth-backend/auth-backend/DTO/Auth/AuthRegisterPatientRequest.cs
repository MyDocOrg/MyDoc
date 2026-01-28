using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace auth_backend.DTO.Auth
{
    public record AuthRegisterPatientRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        [StringLength(100)]
        [Unicode(false)]
        public string? full_name { get; set; }

        public DateOnly? birth_date { get; set; }

        [StringLength(1)]
        [Unicode(false)]
        public string? gender { get; set; }

        [StringLength(20)]
        [Unicode(false)]
        public string? phone { get; set; }

        [StringLength(200)]
        [Unicode(false)]
        public string? address { get; set; }

        public bool? is_active { get; set; }

        public int RoleId { get; set; }

        public int ApplicationId { get; set; }

        public int SuscriptionId { get; set; }
    }
}
