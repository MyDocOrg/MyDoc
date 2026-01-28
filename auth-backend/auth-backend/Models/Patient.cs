using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace auth_backend.Models
{
    public class Patient
    {
        [Key]
        public int id { get; set; }

        public int? user_id { get; set; }

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

        [StringLength(100)]
        [Unicode(false)]
        public string? email { get; set; }

        [StringLength(200)]
        [Unicode(false)]
        public string? address { get; set; }

        public bool is_active { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }
    }
}
