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

        /// <summary>
        /// Rol del paciente. Debe ser 3 (Paciente). Si no se especifica, se asigna automáticamente.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Aplicación MyDoc. Debe ser 1. Si no se especifica, se asigna automáticamente.
        /// </summary>
        public int ApplicationId { get; set; }

        /// <summary>
        /// Suscripción gratuita para pacientes. Debe ser 1. Si no se especifica, se asigna automáticamente.
        /// </summary>
        public int SuscriptionId { get; set; }
    }
}
