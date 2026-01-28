using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace auth_backend.Models
{
    public class Doctor
    {
        [Key]
        public int id { get; set; }

        public int? user_id { get; set; }

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

        [StringLength(100)]
        [Unicode(false)]
        public string? email { get; set; }

        public bool is_active { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }
    }
}
