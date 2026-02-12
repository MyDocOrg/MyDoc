using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace auth_backend.DTO.Auth
{
    public record AuthRegisterPatientRequest
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

        public DateOnly? birth_date { get; set; }

        /// <summary>
        /// Género del paciente. Solo acepta "H" (Hombre) o "M" (Mujer).
        /// </summary>
        [StringLength(1)]
        [Unicode(false)]
        [RegularExpression(@"^[HM]$", ErrorMessage = "El género debe ser 'H' (Hombre) o 'M' (Mujer)")]
        public string? gender { get; set; }

        [StringLength(20)]
        [Unicode(false)]
        public string? phone { get; set; }

        [StringLength(200)]
        [Unicode(false)]
        public string? address { get; set; }

        public bool? is_active { get; set; }

        /// <summary>
        /// Rol del paciente. Valor fijo: 3 (Paciente). Se asigna automáticamente.
        /// </summary>
        public int RoleId { get; set; } = 3;

        /// <summary>
        /// Aplicación MyDoc. Valor fijo: 1. Se asigna automáticamente.
        /// </summary>
        public int ApplicationId { get; set; } = 1;

        /// <summary>
        /// Suscripción de paciente. Valor fijo: 1 (Suscripción gratuita). Se asigna automáticamente.
        /// </summary>
        public int SuscriptionId { get; set; } = 1;
    }
}
