using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace auth_backend.DTO.Auth
{
    public record AuthRegisterDoctorRequest
    {
        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "La contraseña es requerida")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string Password { get; set; } = null!;

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

        /// <summary>
        /// Rol del doctor. Valor fijo: 2 (Doctor). Se asigna automáticamente.
        /// </summary>
        public int RoleId { get; set; } = 2;

        /// <summary>
        /// Aplicación MyDoc. Valor fijo: 1. Se asigna automáticamente.
        /// </summary>
        public int ApplicationId { get; set; } = 1;

        /// <summary>
        /// Suscripción de doctor. Puede ser 1 (Gratuita) o 2 (Premium). Por defecto: 1.
        /// </summary>
        public int SuscriptionId { get; set; } = 1;
    }
}
